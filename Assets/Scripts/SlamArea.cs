using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamArea : MonoBehaviour
{
    [SerializeField]
    private float pushbackForce;
    [SerializeField]
    private float damage;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Hit tag: {other.tag}");

        if (other.gameObject.tag == "Enemy")
        {
            AIHealth aiHealth = other.gameObject.GetComponent<AIHealth>();

            if (aiHealth != null)
            {
                aiHealth.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Enemy does not have an AIHealth script.");
            }
        }

        if (other.gameObject.tag != "Player" /*other.CompareTag("Player")*/)
        {
            if(other.gameObject.GetComponent<Rigidbody>() != null)
            {
            Vector3 pushbackDirection = -(other.transform.position - transform.position);

            pushbackDirection =- pushbackDirection.normalized;

            other.GetComponent<Rigidbody>().AddForce(pushbackDirection * pushbackForce * 100);
            Debug.Log("Push hit" + pushbackDirection);
            }
        }
    }
}
