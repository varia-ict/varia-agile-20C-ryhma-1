using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLevel : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "prize")
        {
            SceneManager.LoadScene("Level2");
        }       
        else if (collision.collider.tag == "prize2")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
