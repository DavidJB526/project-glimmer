using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBob : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float height;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, height), transform.position.z);
    }
}
