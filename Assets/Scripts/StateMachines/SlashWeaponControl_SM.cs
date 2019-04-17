using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashWeaponControl_SM : StateMachineBehaviour
{
    private GameObject swordRight;
    private GameObject swordLeft;

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (swordRight == null)
        {
            swordRight = animator.GetComponent<WeaponLinker>().swordRight;
        }

        if (swordLeft == null)
        {
            swordLeft = animator.GetComponent<WeaponLinker>().swordLeft;
        }

        swordRight.SetActive(true);
        swordLeft.SetActive(true);
    }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        swordRight.SetActive(false);
        swordLeft.SetActive(false);
    }
}
