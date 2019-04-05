using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility_Shield : PlayerAbility
{
    private Animator anim;
    private bool isShielded;
    private bool onCooldown;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentActiveTime >= activeTime)
        {
            isShielded = false;
            isActive = false;
            onCooldown = true;
            currentCooldownTime = cooldownTime - ((Mathf.Round(activeTime - currentActiveTime) * 10) / 10);
            currentActiveTime = 0;
        }
        //this needs to be rewritten at some point

        if (Input.GetButtonDown("Shield") && !anim.GetBool("SlashMode") && !onCooldown && GetComponent<PlayerAbility_SlamAttack>().currentCooldownTime <= 3)
        {
            isShielded = true;
            isActive = true;
            currentActiveTime = currentCooldownTime;
            //SetCanMoveFalse();
        }
        else if (!onCooldown && (Input.GetButtonUp("Shield") || Input.GetButton("Slam Attack")))
        {
            isShielded = false;
            //isActive = false;
            currentCooldownTime = cooldownTime - ((Mathf.Round(activeTime - currentActiveTime) * 10) / 10);
        }
        else if (currentActiveTime <= 0)
        {
            isActive = false;
        }

        if (currentCooldownTime <= 0)
        {
            onCooldown = false;
        }

        anim.SetBool("Blocking", isShielded);

        UpdateActive();
        UpdateActiveUI();
        UpdateCooldown();
        UpdateCooldownUI();
    }

    protected override void UpdateActive()
    {
        if (!isShielded && !onCooldown)
        {
            currentActiveTime = currentCooldownTime;
        }
        else
        {
            base.UpdateActive();
        }
    }
}
