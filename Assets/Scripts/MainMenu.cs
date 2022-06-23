using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
     SceneManager.LoadScene("GameCanchaNueva 1");
    }
    public void GoToMenu()
    {
     SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
     Debug.Log("QUIT");
     Application.Quit();    
    }
}
