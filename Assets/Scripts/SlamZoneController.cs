using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamZoneController : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 3f;

    void Start()
    {
        float startingIntensity;

        Destroy(gameObject, lifetime);
        startingIntensity = GetComponentInChildren<Light>().intensity;
    }
}
