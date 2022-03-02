using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameworld-level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
