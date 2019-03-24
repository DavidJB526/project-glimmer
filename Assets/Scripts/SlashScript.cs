using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Deal Damage here
        }
        else if(other.tag != "Player" && other.tag != "Shield")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }        
    }
}
