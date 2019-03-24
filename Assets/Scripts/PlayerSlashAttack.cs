using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashAttack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody slashObject;
    [SerializeField]
    private Transform slashSpawner;
    [SerializeField]
    private float slashSpeed;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Slash Attack"))
        {
            anim.SetTrigger("SlashAttack");
        }
    }

    private void SpawnSlash(float angle)
    {
        Rigidbody slashClone;

        slashClone = Instantiate(slashObject, slashSpawner.position, slashSpawner.rotation * Quaternion.Euler(0, 0, angle)) as Rigidbody;
        slashClone.velocity = transform.TransformDirection(slashSpawner.forward * slashSpeed);
        anim.ResetTrigger("SlashAttack");
    }
}
