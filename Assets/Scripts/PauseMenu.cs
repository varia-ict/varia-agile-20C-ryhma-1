using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }


    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }



    public void ShowScore()
    {
        Debug.Log("Showing score....");
        //Score will be added later...

    }







}
