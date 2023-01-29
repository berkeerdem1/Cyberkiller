using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused = false;


    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause menu");
            if (isPaused)
            {
                resumegame();
            }
            else
            {
                pausegame();
            }
        }
    }

    public void pausegame()
    {
        PauseMenu.SetActive(true);
        //Time.timeScale=0f;
        //GoToMainMenu();
    }
    public void resumegame()
    {
        PauseMenu.SetActive(false);
        //Time.timeScale=1f;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MaınMenu");
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
