using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackDistance = 5;
    [SerializeField]
    private float raycastRadius = 2;
    [SerializeField]
    private int playerLayer = 9;

    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * attackDistance, Color.magenta);

        if (Input.GetButtonDown("Light Attack"))
        {
            anim.SetTrigger("LightAttack");
        }
        else if (Input.GetButtonDown("Heavy Attack"))
        {
            anim.SetTrigger("HeavyAttack");
        }
    }

    private void DamageEnemy()
    {
        RaycastHit hitInfo;

        Physics.SphereCast(transform.position, raycastRadius, transform.forward, out hitInfo, attackDistance, playerLayer);
    }
}
