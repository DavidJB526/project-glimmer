using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AIHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetTrigger("flinch");
    }
}
