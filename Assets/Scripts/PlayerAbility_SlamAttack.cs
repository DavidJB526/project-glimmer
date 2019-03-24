using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility_SlamAttack : PlayerAbility
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Slam Attack") && currentCooldownTime <= 0)
        {
            anim.SetTrigger("SlamAttack");
            currentCooldownTime = cooldownTime;
        }

        UpdateCooldown();
        UpdateUI();
    }
}
