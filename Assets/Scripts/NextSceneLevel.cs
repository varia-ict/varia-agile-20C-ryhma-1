using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SilverTrophy")
        {
            SceneManager.LoadScene(1);
            Debug.Log("Load scene 2");
            
        }       
        else if (other.tag == "BronzeTrophy")
        {
            SceneManager.LoadScene(2);
            Debug.Log("Load scene 3");
        }
    }
}
