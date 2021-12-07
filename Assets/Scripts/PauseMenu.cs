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
    private bool isShowingStop = true;
    public GameObject pauseMenu;
    public Button button;
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
        }

    }


    public void Resume()
    {
        if(gameManager.CollectedItems < 10)
        {
            PickUpScore.SetActive(true);
        } else
        {
            challenge.SetActive(true);
            PickUpScore.SetActive(false);
        }

        effect1.SetActive(true);
        effect2.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        button.Select();
    }

    public void Pause()
    {
        effect1.SetActive(false);
        effect2.SetActive(false);
        PickUpScore.SetActive(false);
        challenge.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        isShowingStop = true;

    }


    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }



    public void ShowScore()
    {
        score.gameObject.SetActive(true);
        isShowingScore = true;


        isShowingStop = false;
        pauseMenu.SetActive(false);

    }







}
