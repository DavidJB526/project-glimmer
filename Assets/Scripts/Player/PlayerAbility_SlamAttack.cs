using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility_SlamAttack : PlayerAbility
{
    [SerializeField]
    private GameObject slamZone;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Slam Attack") && currentCooldownTime <= 0 && !anim.GetBool("SlashMode"))
        {
            anim.SetTrigger("SlamAttack");
            currentCooldownTime = cooldownTime;
            SetCanMoveFalse();
        }

        UpdateCooldown();
        UpdateCooldownUI();
    }

    //Is an Event in the Animator
    private void SpawnSlamZone()
    {
        GameObject slamZoneClone;

        slamZoneClone = Instantiate(slamZone, transform.position, transform.rotation) as GameObject;;
    }
}
