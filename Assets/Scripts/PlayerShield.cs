using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private Animator anim;
    private bool isShielded;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shield"))
        {
            isShielded = true;
        }
        else if (Input.GetButtonUp("Shield"))
        {
            isShielded = false;
        }

        anim.SetBool("Blocking", isShielded);
        anim.ResetTrigger("SlamAttack");
    }
}
