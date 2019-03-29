using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField]
    protected Slider cooldownSlider;
    [SerializeField]
    protected Text cooldownText;
    [SerializeField]
    protected float cooldownTime;
    [SerializeField]
    protected Slider activeSlider;
    [SerializeField]
    protected Text activeText;
    [SerializeField]
    protected float activeTime;

    public float currentCooldownTime;
    protected float currentActiveTime;
    protected bool isActive;

    protected void UpdateCooldownUI()
    {
        cooldownText.text = (Mathf.Round(currentCooldownTime * 10) / 10).ToString();
        cooldownSlider.maxValue = cooldownTime;
        cooldownSlider.value = currentCooldownTime;

        if (currentCooldownTime <= 0 || isActive)
        {
            cooldownText.gameObject.SetActive(false);
            cooldownSlider.gameObject.SetActive(false);
        }
        else
        {
            cooldownText.gameObject.SetActive(true);
            cooldownSlider.gameObject.SetActive(true);
        }
    }

    protected void UpdateCooldown()
    {
        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            //isActive = false;
        }
    }

    protected void UpdateActiveUI()
    {
        activeText.text = (Mathf.Round(currentActiveTime * 10) / 10).ToString();
        activeSlider.maxValue = activeTime;
        activeSlider.value = currentActiveTime;

        activeText.gameObject.SetActive(isActive);
        activeSlider.gameObject.SetActive(isActive);
    }

    protected void UpdateActive()
    {
        if (currentActiveTime >= activeTime && isActive)
        {
            isActive = false;
            currentCooldownTime = cooldownTime;
            currentActiveTime = 0;
        }
        else if (isActive && currentCooldownTime <= cooldownTime)
        {
            currentActiveTime += Time.deltaTime;
        }
    }

    protected void SetCanMoveFalse()
    {
        this.gameObject.GetComponent<PlayerMovement>().canMove = false;
    }

    protected void SetCanMoveTrue()
    {
        this.gameObject.GetComponent<PlayerMovement>().canMove = true;
    }
}
