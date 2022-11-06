using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("James Scene");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("James Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
