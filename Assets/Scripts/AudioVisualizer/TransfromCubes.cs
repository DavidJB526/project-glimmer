using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfromCubes : MonoBehaviour
{
    [SerializeField]
    private bool useBuffer;

    [SerializeField]
    private int bandNumber;

    [SerializeField]
    private float startScale = 1, scaleMultiplier = 10;

    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioSampleCollector.audioBandBuffer[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        }
        else if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioSampleCollector.audioBand[bandNumber] * scaleMultiplier) + startScale, transform.localScale.z);
        }
    }
}
