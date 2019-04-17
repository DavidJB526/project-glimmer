using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeaponControl_SM : StateMachineBehaviour
{
    private GameObject swordRight;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (swordRight == null)
        {
            swordRight = animator.GetComponent<WeaponLinker>().swordRight;
        }

        swordRight.SetActive(true);
    }

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    if (swordRight == null)
    //    {
    //        swordRight = animator.GetComponent<WeaponLinker>().swordRight;
    //    }
    //    swordRight.SetActive(true);
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        swordRight.SetActive(false);
    }
}
