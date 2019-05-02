using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Pickup : MonoBehaviour
{
    private ParticleSystem[] particleSystems;
    private Renderer[] renderers;
    private BoxCollider boxCollider;

    private void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        renderers = GetComponentsInChildren<Renderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (ParticleSystem p in particleSystems)
        {
            p.Stop(true);
        }

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        boxCollider.enabled = false;
    }
}
