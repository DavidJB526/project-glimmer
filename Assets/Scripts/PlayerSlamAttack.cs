using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlamAttack : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Slam Attack"))
        {
            anim.SetTrigger("SlamAttack");
        }
    }
}
