using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void StartGame(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
