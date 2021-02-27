using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MovementController))]
public class PlayerController : IController
{
    public LayerMask clickable;
    private float tempCount;
    private float comboCount;
    private Vector3 distance;
    public Interactable focus;
    MovementController movement;
    public Skill[] skills;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tempCount = timer;

        movement = GetComponent<MovementController>();

        if(GameManager.instance.player != this.gameObject)
        {
            GameManager.instance.player = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!isDead)
        {
            RemoveFocus();
            //anim.SetBool("IsAttacking", false);

            if (Input.GetMouseButton(0))
            {
                Move();
            }
            if (Input.GetMouseButton(1))
            {
                Interact();
            }
            if(Input.GetMouseButtonUp(1))
            {
                anim.SetBool("IsAttacking", isAttacking = false);
                agent.SetDestination(transform.position);
                RemoveFocus();
            }
            CheckIfMoving();
        }
        else
        {
            agent.isStopped = true;
            
        }
    }

    private void Move()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, 100, clickable))
        {
            movement.MoveToPoint(hit.point);
            RemoveFocus();
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
        var level = GetComponent<PlayerStats>().level;
        skills[skillToActivate].ActivateSkill(anim, level);
    }
}
