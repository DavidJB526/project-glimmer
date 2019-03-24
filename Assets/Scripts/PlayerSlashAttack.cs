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
        if (Input.GetButton("Slash Attack"))
        {
            anim.SetTrigger("SlashAttack");
        }
    }

    private void SpawnSlashRight()
    {
        Rigidbody slashClone;

        slashClone = Instantiate(slashObject, slashSpawner.position, slashSpawner.rotation * Quaternion.Euler(0, 0, 45)) as Rigidbody;
        slashClone.velocity = transform.TransformDirection(slashSpawner.forward * slashSpeed);
        anim.ResetTrigger("SlashAttack");
    }

    private void SpawnSlashLeft()
    {
        Rigidbody slashClone;

        slashClone = Instantiate(slashObject, slashSpawner.position, slashSpawner.rotation * Quaternion.Euler(0, 0, -45)) as Rigidbody;
        slashClone.velocity = transform.TransformDirection(slashSpawner.forward * slashSpeed);
        anim.ResetTrigger("SlashAttack");
    }
}
