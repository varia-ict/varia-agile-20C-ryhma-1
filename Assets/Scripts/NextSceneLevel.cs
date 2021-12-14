using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{
    private GameManager gameManager;
    private bool winTriggered;
    public GameObject winObject;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hotdog" && gameManager.CollectedItems >= 10)
        {
            SceneManager.LoadScene(2);   
        }       
        else if (other.tag == "Burger" && gameManager.CollectedItems >= 10)
        {
            SceneManager.LoadScene(3);
        }
        else if (other.tag == "Steak" && gameManager.CollectedItems >= 10)
        {
            winTriggered = true;
        }
    }

    void FixedUpdate()
    {
        if (winTriggered == true)
        {
            winObject.gameObject.SetActive(true);
        }
}
}
