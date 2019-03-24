using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility_SlashAttack : PlayerAbility
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
        if (Input.GetButtonDown("Slash Attack") && currentCooldownTime <= 0)
        {
            anim.SetTrigger("SlashAttack");
            currentCooldownTime = cooldownTime;
        }

        UpdateCooldown();
        UpdateUI();
    }

    private void SpawnSlash(float angle)
    {
        Rigidbody slashClone;

        slashClone = Instantiate(slashObject, slashSpawner.position, slashSpawner.rotation * Quaternion.Euler(0, 0, angle)) as Rigidbody;
        slashClone.velocity = transform.TransformDirection(slashSpawner.forward * slashSpeed);
        anim.ResetTrigger("SlashAttack");
    }
}
