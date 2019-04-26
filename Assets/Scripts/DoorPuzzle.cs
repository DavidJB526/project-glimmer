using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorPuzzle : MonoBehaviour
{
    [SerializeField]
    private DoorPuzzleTrigger trigger45pos;
    [SerializeField]
    private DoorPuzzleTrigger trigger45neg;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (trigger45pos.isTriggered && trigger45neg.isTriggered)
        {
            anim.SetTrigger("openDoor");
        }
    }
}
