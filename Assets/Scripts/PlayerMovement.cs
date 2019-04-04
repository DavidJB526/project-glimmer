using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Prevents this script from being attached to more than one GameObject in a scene
[DisallowMultipleComponent]

//GameObjects with this script require the components below, a component will be added if one does not exist
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

//This script goes on the player
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject cm_MainCamera;
    [SerializeField]
    private float rotateSpeed;

    private Animator anim;
    private Rigidbody rb;
    public bool canMove;

    Vector3 direction;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        canMove = true;
        //direction = new Vector3((Input.GetAxis("Horizontal")), 0, (Input.GetAxis("Vertical")));

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //adjusts the float value for "MoveZ" denoted in the attached Animator based on Vertical input
        anim.SetFloat("MoveVertical", Input.GetAxis("Vertical"));
        //adjusts the float value for "MoveX" denoted in the attached Animator based on Horizontal input
        anim.SetFloat("MoveHorizontal", Input.GetAxis("Horizontal"));
    }

    private void Rotate()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || anim.GetBool("SlashMode"))
        {
            if (canMove)
            {
                //look with Camera
                transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
                //lock rotation to only the Y axis
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            }   
        }
    }
}
