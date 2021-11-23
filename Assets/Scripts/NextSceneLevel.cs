using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SilverTrophy")
        {
            SceneManager.LoadScene("Gameworld-level 2");
            Debug.Log("Load scene 2");
            
        }       
        else if (collision.collider.tag == "BronzeTrophy")
        {
            SceneManager.LoadScene("Gameworld-level 3");
            Debug.Log("Load scene 3");
        }
    }
}
