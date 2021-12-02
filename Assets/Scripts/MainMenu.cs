using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject Menu;
    public EventSystem EventSystem;
    public GameObject easy;
    public Button selectedButton;
    public GameObject medium;
    public GameObject hard;

    


    private void Start()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Gameworld-level1");
    }

    public void Options()
    {
        OptionsMenu.gameObject.SetActive(true);
        
        
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        OptionsMenu.gameObject.SetActive(false);
        selectedButton.Select();

    }


    public void ChooseEasy()
    {
        easy.gameObject.SetActive(true);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
    }
    public void ChooseMedium()
    {
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(true);
        hard.gameObject.SetActive(false);
    }

    public void ChooseHard()
    {
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(true);
    }

}
