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
        if (Input.GetButtonDown("Slash Attack") && currentCooldownTime <= 0 && !isActive && !anim.GetBool("Blocking"))
        {
            currentActiveTime = 0;
            isActive = true;
        }

        if (Input.GetButtonDown("Light Attack") && isActive)
        {
            anim.SetTrigger("LightAttack");
        }
        //else if (!isActive)
        //{
        //    anim.ResetTrigger("LightAttack");
        //}

        anim.SetBool("SlashMode", isActive);

        UpdateActive();
        UpdateActiveUI();
        UpdateCooldown();
        UpdateCooldownUI();
    }

    private void SpawnSlash(float angle)
    {
        Rigidbody slashClone;

        slashClone = Instantiate(slashObject, slashSpawner.position, slashSpawner.rotation * Quaternion.Euler(0, 0, angle)) as Rigidbody;
        slashClone.velocity = slashSpawner.forward * slashSpeed;
        anim.ResetTrigger("LightAttack");
    }
}
