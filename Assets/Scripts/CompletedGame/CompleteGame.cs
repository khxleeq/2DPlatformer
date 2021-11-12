using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    public void MainMenutBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void QuitBtn()
    {
        Application.Quit();
    }
    
}
