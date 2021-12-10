using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hotdog" && gameManager.CollectedItems >= 10)
        {
            SceneManager.LoadScene(1);   
        }       
        else if (other.tag == "Burger" && gameManager.CollectedItems >= 10)
        {
            SceneManager.LoadScene(2);
        }
    }
}
