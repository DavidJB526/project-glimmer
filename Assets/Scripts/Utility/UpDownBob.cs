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
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.parent.position.y, transform.parent.position.y + height, Mathf.PingPong(Time.time * speed, 1)), transform.position.z);
    }
}
