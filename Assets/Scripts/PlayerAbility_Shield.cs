using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility_Shield : PlayerAbility
{
    private Animator anim;
    private bool isShielded;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shield") && currentCooldownTime <= 0)
        {
            isShielded = true;
        }
        else if (Input.GetButtonUp("Shield"))
        {
            isShielded = false;
            if (currentCooldownTime <= 0)
            {
                currentCooldownTime = cooldownTime;
            }            
        }

        anim.SetBool("Blocking", isShielded);
        anim.ResetTrigger("SlamAttack");

        UpdateCooldown();
        UpdateCooldownUI();
    }
}
