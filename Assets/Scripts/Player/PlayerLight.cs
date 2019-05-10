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
            anim.SetBool("usingLight", !anim.GetBool("usingLight"));
            lightToToggle.enabled = !lightToToggle.enabled;
        }
    }
}
