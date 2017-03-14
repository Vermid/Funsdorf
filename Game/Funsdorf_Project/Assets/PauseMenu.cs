using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject QuitUI;
    public Button startText;
    public Button exitText;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
        QuitUI.SetActive(false);
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused; //toogle true to false and false to true
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;  // if you want slow motion use 0.1- 0.9 
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        int ActivSeceneIndex = SceneManager.GetActiveScene().buildIndex;  //buildIndex returns INT 
        SceneManager.LoadScene(ActivSeceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        QuitUI.SetActive(true);
        Application.Quit();
    }

    public void ExitPress()
    {
        QuitUI.SetActive (true);
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void NoPress()
    {
        QuitUI.SetActive(false);
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void VolumeControl(float volumeControl)
    {
        AudioListener.volume = volumeControl;
    }
}