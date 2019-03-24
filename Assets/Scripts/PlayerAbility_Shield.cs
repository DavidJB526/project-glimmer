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
        //this needs to be rewritten at some point
        if (Input.GetButtonDown("Shield") && currentCooldownTime <= 0 && !anim.GetBool("SlashMode") && GetComponent<PlayerAbility_SlamAttack>().currentCooldownTime <= 3)
        {
            isShielded = true;
            isActive = true;
            currentActiveTime = 0;
        }
        else if (Input.GetButtonUp("Shield") || Input.GetButton("Slam Attack"))
        {
            isShielded = false;
            isActive = false;
            if (currentCooldownTime <= 0)
            {
                currentCooldownTime = cooldownTime - ((Mathf.Round(activeTime - currentActiveTime) * 10) / 10);
            }            
        }
        else if (currentActiveTime >= activeTime)
        {
            isShielded = false;
            isActive = false;
            currentCooldownTime = cooldownTime;
            currentActiveTime = 0;
        }

        anim.SetBool("Blocking", isShielded);
        //anim.ResetTrigger("SlamAttack");

        UpdateActive();
        UpdateActiveUI();
        UpdateCooldown();
        UpdateCooldownUI();
    }
}
