using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private bool isShowingScore = false;
    private bool isShowingRestart = false;
    private bool isShowingStop = true;
    public GameObject pauseMenu;
    public GameObject restart;
    public Button button;
    public Button button2;
    public Button button3;
    public GameObject score;
    public GameObject PickUpScore;
    public GameObject challenge;
    private GameManager gameManager;
    public GameObject effect1;
    public GameObject effect2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isShowingStop == true)
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

        if(Input.GetKeyDown(KeyCode.Escape) && isShowingScore == true)
        {
            score.gameObject.SetActive(false);
            isShowingScore = false;
            pauseMenu.SetActive(true);
            isShowingStop = true;
            button.Select();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isShowingRestart == true)
        {
            restart.gameObject.SetActive(false);
            isShowingRestart = false;
            pauseMenu.SetActive(true);
            isShowingStop = true;
            button.Select();
        }



    }


    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (gameManager.CollectedItems < 10)
        {
            PickUpScore.gameObject.SetActive(true);
        } else
        {
            challenge.gameObject.SetActive(true);
            PickUpScore.gameObject.SetActive(false);
        }

        effect1.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        button.Select();
        gameManager.endBool = true;
    }

    public void Pause()
    {
        effect1.SetActive(false);
        PickUpScore.gameObject.SetActive(false);
        challenge.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        isShowingStop = true;
        Cursor.lockState = CursorLockMode.None;
        gameManager.endBool = false;

    }

    public void ShowScore()
    {
        score.gameObject.SetActive(true);
        isShowingScore = true;
        button3.Select();
        isShowingStop = false;
        pauseMenu.SetActive(false);

    }



   public void Restart()
    {
        restart.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        isShowingRestart = true;
        isShowingStop = false;
        button2.Select();
    }



    public void Back() {

        restart.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        isShowingRestart= false;
        isShowingStop = true;
        button.Select();
    }


    public void Back2() {
        score.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        isShowingScore = false;
        isShowingStop = true;
        button.Select();
    }






    public void RestartGame()
    {
        SceneManager.LoadScene("Gameworld-level1");
    }



    public void RestartLevel()
    {
        if (gameManager.sceneName == "Gameworld-level1")
        {
            SceneManager.LoadScene("Gameworld-level1");
        }
        else if (gameManager.sceneName == "Gameworld-level2")
        {
            SceneManager.LoadScene("Gameworld-level2");
        }
        else if (gameManager.sceneName == "Gameworld-level3")
        {
            SceneManager.LoadScene("Gameworld-level3");
        }

    }

    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
