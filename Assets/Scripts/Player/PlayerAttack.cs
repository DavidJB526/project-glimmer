using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform raycastOrigin;
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
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * attackDistance, Color.magenta);

        if (Input.GetButtonDown("Light Attack"))
        {
            anim.SetTrigger("LightAttack");
        }
        else if (Input.GetButtonDown("Heavy Attack"))
        {
            anim.SetTrigger("HeavyAttack");
        }
    }

    /// <summary>
    /// This function will go on Animation Events at the point in which the Player deals damage
    /// </summary>
    private void DamageEnemy(float damage)
    {
        RaycastHit[] hitInfo;

        //if (Physics.SphereCast(raycastOrigin.position, raycastRadius, raycastOrigin.forward, out hitInfo, attackDistance, playerLayer))
        //{
        //    Debug.Log($"Hit: {hitInfo.collider.tag}");

        //    if (hitInfo.collider.CompareTag("Enemy"))
        //    {

        //    }
        //}

        hitInfo = Physics.SphereCastAll(raycastOrigin.position, raycastRadius, raycastOrigin.forward, attackDistance, playerLayer);

        foreach(RaycastHit raycastHit in hitInfo)
        {
            Debug.Log($"Hit: {raycastHit.collider.name}. Dealt {damage} Damage.");

            if (raycastHit.collider.CompareTag("Enemy"))
            {

            }
        }
    }
}
