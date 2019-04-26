using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityActivationTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerAbility abilityScript;
    [SerializeField]
    private GameObject abilityCanvas;
    ///This is correct, but not being recognized by the API
    [SerializeField]
    private TextMeshProUGUI instructionText;

    private Text testText;

    [SerializeField]
    [TextArea(3, 8)]
    private string instructions;

    private void Awake()
    {
        abilityScript.enabled = false;
        abilityCanvas.SetActive(false);
        instructionText.CrossFadeAlpha(0, 0, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            abilityScript.enabled = true;
            abilityCanvas.SetActive(true);
            instructionText.text = instructions;
            StartCoroutine(FadeTextInAndOut());
        }
    }

    IEnumerator FadeTextInAndOut()
    {
        instructionText.CrossFadeAlpha(1, 2, true);
        yield return new WaitForSeconds(4f);
        instructionText.CrossFadeAlpha(0, 1, true);
    }
}
