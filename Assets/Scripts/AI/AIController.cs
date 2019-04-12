using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;

    private AICombat combat;
    private Animator anim;
    private Transform target;
    private NavMeshAgent agent;

    private void Awake()
    {
        combat = GetComponent<AICombat>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            //anim.SetBool("ChasePlayer", true);

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                //anim.SetBool("ChasePlayer", true);
                FaceTarget();
                //anim.SetBool("ChasePlayer", false);
            }
            else
            {
                //anim.SetBool("ChasePlayer", false);
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    /// <summary>
    /// Sets NavMeshAgent velocity to be the same as the Root Motion of the Animations
    /// </summary>
    //private void OnAnimatorMove()
    //{
    //    agent.velocity = anim.deltaPosition / Time.deltaTime;
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
