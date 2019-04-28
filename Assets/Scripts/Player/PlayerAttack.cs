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

        hitInfo = Physics.SphereCastAll(raycastOrigin.position, raycastRadius, raycastOrigin.forward, attackDistance, playerLayer);

        foreach(RaycastHit raycastHit in hitInfo)
        {
            Debug.Log($"Hit: {raycastHit.collider.name}. Dealt {damage} Damage.");

            if (raycastHit.collider.CompareTag("Enemy"))
            {
                AIHealth aiHealth = raycastHit.collider.GetComponent<AIHealth>();

                if (aiHealth != null)
                {
                    aiHealth.TakeDamage(damage);
                }
                else
                {
                    Debug.Log("Enemy does not have an AIHealth script.");
                }
            }
        }
    }

    /// <summary>
    /// This would be called in the Animator to rotate towards camera at start of animation.
    /// Probably not the best way to do this, currenlty excluded.
    /// </summary>
    private void RotateWithAttack()
    {
        //look with Camera
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
        //lock rotation to only the Y axis
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
