using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AIHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    public bool tookDamage;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }

    public void TakeDamage(float damage)
    {
        tookDamage = true;
        health -= damage;
        anim.SetTrigger("flinch");
    }
}
