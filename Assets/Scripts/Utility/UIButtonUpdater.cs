using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonUpdater : MonoBehaviour
{
    [SerializeField]
    private string controllerInput;
    [SerializeField]
    private string keyboardInput;

    private Text buttonText;

    private void Start()
    {
        buttonText = GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            buttonText.text = controllerInput;
        }
        else
        {
            buttonText.text = keyboardInput;
        }
    }
}
