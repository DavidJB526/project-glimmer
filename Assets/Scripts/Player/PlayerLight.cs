using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerLight : MonoBehaviour
{
    [SerializeField]
    private Light lightToToggle;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        lightToToggle.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Light"))
        {
            anim.SetBool("usingLight", true);
            lightToToggle.enabled = true;
        }
        else if (Input.GetButtonUp("Light"))
        {
            anim.SetBool("usingLight", false);
            lightToToggle.enabled = false;
        }
    }
}
