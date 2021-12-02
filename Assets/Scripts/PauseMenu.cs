using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private bool isShowingScore = false;
    private bool isShowingStop = true;
    public GameObject pauseMenu;
    public Button button;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {

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
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        button.Select();
    }

    public void Pause()
    {

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
