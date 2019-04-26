using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 3f;
    [SerializeField]
    private float damage;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            AIHealth aiHealth = other.GetComponent<AIHealth>();

            if (aiHealth != null)
            {
                aiHealth.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Enemy does not have an AIHealth script.");
            }
        }
        else if (other.tag != "Player" && other.isTrigger == false)
        {
            Destroy(gameObject);
        }
    }
}
