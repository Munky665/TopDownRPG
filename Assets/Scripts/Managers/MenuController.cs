using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuButton
{
    Start,          //0
    MainOptions,    //1
    Restart,        //2
    Exit,           //3
    Continue,       //4
    back,           //5
    MainMenu        //6
}


public class MenuController : MonoBehaviour
{

    public List<GameObject> MenuButtons;
    public List<GameObject> OptionMenuButtons;
    public List<GameObject> GameOverMenu;
    public GameObject pauseTitle;

    bool paused = false;

    private void Update()
    {
        if (paused == false && SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                foreach (GameObject g in MenuButtons) 
                {
                    g.SetActive(true);
                }
                pauseTitle.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if(paused == true && SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                foreach (GameObject g in OptionMenuButtons)
                {
                    g.SetActive(false);
                }
                foreach(GameObject g in MenuButtons)
                {
                    g.SetActive(false);
                }
                pauseTitle.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if(GameManager.instance.player.GetComponent<Stats>().health <= 0)
        {
            foreach(GameObject g in GameOverMenu)
            {
                g.SetActive(true);
            }
        }
    }

    public void MenuButtonClicked(int b)
    {
        switch ((MenuButton)b)
        {
            case MenuButton.Start:
                SceneManager.LoadScene(1);
                break;
            case MenuButton.MainOptions:
                foreach (GameObject g in OptionMenuButtons)
                {
                    g.SetActive(true);
                }
                foreach (GameObject g in MenuButtons)
                {
                    g.SetActive(false);
                }
                break;
            case MenuButton.Restart:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case MenuButton.Continue:
                foreach (GameObject g in OptionMenuButtons)
                {
                    g.SetActive(false);
                }
                foreach (GameObject g in MenuButtons)
                {
                    g.SetActive(false);
                }
                pauseTitle.SetActive(false);
                Time.timeScale = 1;
                break;
            case MenuButton.Exit:
                Application.Quit();
                break;
            case MenuButton.back:
                foreach(GameObject g in OptionMenuButtons)
                {
                    g.SetActive(false);
                }
                foreach(GameObject g in MenuButtons)
                {
                    g.SetActive(true);
                }
                break;
            case MenuButton.MainMenu:
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                break;

        }

    }
}
