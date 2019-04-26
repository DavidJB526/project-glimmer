using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AIHealth))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    [SerializeField]
    private float maxLookRadius = 10f;
    [SerializeField]
    private float minLookRadius = 5f;

    private AIHealth aiHealth;
    private Animator anim;
    private Transform target;
    private NavMeshAgent agent;

    private Vector3 direction;

    private void Awake()
    {
        aiHealth = GetComponent<AIHealth>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    private void Update()
    {
        UpdateAIBehavior();
    }

    private void UpdateAIBehavior()
    {
        direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(target.position, transform.position);
        float angle = Vector3.Angle(direction, transform.forward);

        if ((distance <= maxLookRadius && angle < 30) || distance <= minLookRadius)
        {
            agent.SetDestination(target.position);
            agent.destination = target.position;

            if (distance <= agent.stoppingDistance)
            {
                anim.SetBool("chasePlayer", false);
                MeleeAttack();
                FaceTarget();
            }
            else
            {
                anim.SetBool("chasePlayer", true);
                anim.ResetTrigger("attackPlayer");
            }
        }
        else if (aiHealth.tookDamage)
        {
            agent.SetDestination(target.position);
            anim.SetBool("chasePlayer", true);
        }
    }

    private void MeleeAttack()
    {
        anim.SetBool("chasePlayer", false);
        anim.SetTrigger("attackPlayer");
    }

    private void FaceTarget()
    {
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    //This method is called through an event on the AI's respective "Death" Animation
    private void RemoveCreature()
    {
        Destroy(gameObject);
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxLookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minLookRadius);
    }

}
