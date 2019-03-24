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

    public void UpdateUI()
    {
        cooldownText.text = (Mathf.Round(currentCooldownTime*10)/10).ToString();
        cooldownSlider.maxValue = cooldownTime;
        cooldownSlider.value = currentCooldownTime;

        if (currentCooldownTime <= 0)
        {
            cooldownText.enabled = false;
            cooldownSlider.enabled = false;
        }
        else
        {
            cooldownText.enabled = true;
            cooldownSlider.enabled = true;
        }
    }

    public void UpdateCooldown()
    {
        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
        }
    }
}
