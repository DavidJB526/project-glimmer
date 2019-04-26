using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DoorPuzzleTrigger : MonoBehaviour
{
    [SerializeField]
    private float angle;
    [SerializeField]
    private Renderer[] doorLights;
    [SerializeField]
    private Material[] materials;

    public bool isTriggered = false;

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = true;
        foreach (Renderer doorLight in doorLights)
        {
            doorLight.material = materials[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Slash" && other.transform.eulerAngles.z == angle && isTriggered == false)
        {
            isTriggered = true;
            boxCollider.enabled = false;
            foreach(Renderer doorLight in doorLights)
            {
                doorLight.material = materials[1];
            }
        }
    }
}
