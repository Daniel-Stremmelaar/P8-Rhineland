using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void RestartTheScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
