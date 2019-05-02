using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [SerializeField]
    [TextArea(3, 8)]
    private string controllerInstructions;
    [SerializeField]
    [TextArea(3, 8)]
    private string keyboardInstructions;

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        instructionText.CrossFadeAlpha(0, 0, true);
    }

    private void Start()
    {
        abilityScript.enabled = false;
        abilityCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boxCollider.enabled = false;
            if (abilityScript != null)
            {
            abilityScript.enabled = true;
            }
            if (abilityCanvas != null)
            {
            abilityCanvas.SetActive(true);
            }
            if (Input.GetJoystickNames().Length > 0)
            {
                instructionText.text = controllerInstructions;
            }
            else
            {
                instructionText.text = keyboardInstructions;
            }
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
