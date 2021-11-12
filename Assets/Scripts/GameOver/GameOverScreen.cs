
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void PlayAgainBtn()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

