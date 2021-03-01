using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IController : MonoBehaviour
{
    protected Transform target;
    public NavMeshAgent agent { get; private set; }
    protected Animator anim;
    protected float timer = 3;
    public bool isDead = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
    }
    public bool IsMoving
    {
        get
        {
            return isMoving;
        }
    }
    protected bool isAttacking = false;
    protected bool isMoving = false;

    protected void FaceTarget(Vector3 t)
    {
        Vector3 direction = (t - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}
