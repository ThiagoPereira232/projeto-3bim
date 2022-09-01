using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject mainMenu;
    public Dropdown dropdown;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Casinha");
    }

    public void LoadTutorial()
    {
        Time.timeScale = 1f;
        tutorial.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LoadCredits()
    {
        Time.timeScale = 1f;
        tutorial.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void BackMenu()
    {
        Time.timeScale = 1f;
        tutorial.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
