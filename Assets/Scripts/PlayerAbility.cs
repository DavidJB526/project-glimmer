using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    public Slider cooldownSlider;
    public Text cooldownText;
    public float cooldownTime;
    public float currentCooldownTime;

    public Slider activeSlider;
    public Text activeText;
    public float activeTime;
    public float currentActiveTime;
    public bool isActive;

    public void UpdateCooldownUI()
    {
        cooldownText.text = (Mathf.Round(currentCooldownTime * 10) / 10).ToString();
        cooldownSlider.maxValue = cooldownTime;
        cooldownSlider.value = currentCooldownTime;

        if (currentCooldownTime <= 0)
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

    public void UpdateCooldown()
    {
        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            isActive = false;
        }
    }

    public void UpdateActiveUI()
    {
        activeText.text = (Mathf.Round(currentActiveTime * 10) / 10).ToString();
        activeSlider.maxValue = activeTime;
        activeSlider.value = currentActiveTime;

        activeText.gameObject.SetActive(isActive);
        activeSlider.gameObject.SetActive(isActive);
    }

    public void UpdateActive()
    {
        if (currentActiveTime >= activeTime && isActive)
        {
            isActive = false;
            currentCooldownTime = cooldownTime;
        }
        else if (isActive && currentCooldownTime <= cooldownTime)
        {
            currentActiveTime += Time.deltaTime;
        }
    }
}
