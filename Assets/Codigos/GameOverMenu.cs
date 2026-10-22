using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    public void RetryLevel()
    {
        SceneManager.LoadScene("Nivel1");
    }

    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
