using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject optionsPanel;

    void Awake()
    {
        optionsPanel.SetActive(false);
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonOptions()
    {
        startPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("GAME HAS STOPPED");
    }

    public void ButtonBackToStart()
    {
        startPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
