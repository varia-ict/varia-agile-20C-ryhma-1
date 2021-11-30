using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hotdog")
        {
            SceneManager.LoadScene(1);   
        }       
        else if (other.tag == "Burger")
        {
            SceneManager.LoadScene(2);
        }
    }
}

