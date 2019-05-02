using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [System.Serializable]
    public class AnimationToTrigger
    {
        public Animator anim;
        public string animTrigger;

        public void TriggerAnimation()
        {
            anim.SetTrigger(animTrigger);
        }
    }

    [SerializeField]
    private AnimationToTrigger[] animationsToTrigger;

    [SerializeField]
    private GameObject objectToToggle;
    [SerializeField]
    private bool isReusable = true;

    private bool hasBeenUsed = false;

    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            hasBeenUsed = true;
            if (!isReusable)
            {
                displayText = string.Empty;
            }
        }

        if (animationsToTrigger != null)
        {
            foreach (AnimationToTrigger animationToTrigger in animationsToTrigger)
            {
                animationToTrigger.TriggerAnimation();
            }
        }
    }
}
