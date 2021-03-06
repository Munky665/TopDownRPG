﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementController))]
public class PlayerController : IController
{
    public LayerMask clickable;
    public Interactable focus;
    MovementController movement;
    public Skill[] skills;
    public List<GameObject> closeEnemies;
    private PlayerStats pStats;
    public bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        movement = GetComponent<MovementController>();

        if(GameManager.instance.player != this.gameObject)
        {
            GameManager.instance.player = this.gameObject;
        }
        pStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //stop player moving when interacting with UI
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!isDead)
        {
            RemoveFocus();
            //move player to clicked position
            if (Input.GetMouseButton(0))
            {
                if (!isDashing)
                {
                    Move();
                }
            }
            //move player to interactable or attack/pickup interactable
            if (Input.GetMouseButton(1))
            {
                Interact();
            }
            //stop attacking
            if(Input.GetMouseButtonUp(1))
            {
                anim.SetBool("IsAttacking", isAttacking = false);
                agent.SetDestination(transform.position);
                RemoveFocus();
                PlayerSFXManager.instance.source.Stop();
                PlayerSFXManager.instance.source.loop = false;
            }
            CheckIfMoving();
        }
        else
        {
            agent.isStopped = true;
            
        }

        CooldownSkills();
        CheckForDeadEnemies();
    }

    void CheckForDeadEnemies()
    {
        foreach(GameObject e in closeEnemies)
        {
            if(e.GetComponent<IController>().isDead)
            {
                closeEnemies.Remove(e);
                break;
            }
        }
    }

    private void CooldownSkills()
    {
       foreach (Skill s in skills)
        {
            if (s.checkCooling && s.levelRequired <= pStats.level && s.coolingDown)
            {
                StartCoroutine(SkillCoolDown(s));
            }
        }
    }
    IEnumerator SkillCoolDown(Skill s)
    {
        s.checkCooling = false;
        yield return new WaitForSeconds(s.timer);
        try
        {
            s.coolingDown = false;
            print(s.skillObject.name + " Ready to use");
        }
        catch
        {

        }
    }
    private void Move()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, 100, clickable))
        {
            if (!anim.GetBool("IsUsingSkill"))
            {
                movement.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }
    }

    void Interact()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, 100, clickable))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                SetFocus(interactable);
                FaceTarget(hit.collider.gameObject.transform.position);
            }
        }
    }

    void CheckIfMoving()
    {
        if (agent.velocity.magnitude < 1)
        {
            anim.SetBool("IsMoving", isMoving = false);
        }
        else if (agent.velocity.magnitude > 1)
        {
            anim.SetBool("IsMoving", isMoving = true);

        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            newFocus.OnFocused(transform);
        }
        movement.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        movement.StopFollowingTarget();
    }

    public void Attack()
    {
        if (!IsAttacking)
        {
            anim.SetBool("IsMoving", isMoving = false);
            anim.SetBool("IsAttacking", isAttacking = true);
            print("Attacking activated");

        }
       
    }


    public void StopMovmentAnim()
    {
        if (agent.velocity.magnitude < 1)
        {
            anim.SetBool("IsAttacking", isAttacking = true);
        }
        else if (agent.velocity.magnitude > 1)
        {
            anim.SetBool("IsAttacking", isAttacking = false);
        }
    }
    public void ActivateSkill(int skillToActivate)
    {
        isAttacking = true;
        skills[skillToActivate].ActivateSkill(this, skillToActivate, pStats);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && !closeEnemies.Contains(other.gameObject))
        {
            closeEnemies.Add(other.gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && closeEnemies.Contains(other.gameObject))
        {
            closeEnemies.Remove(other.gameObject);
        }
    }


}
