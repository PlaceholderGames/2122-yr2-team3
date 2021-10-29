using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoose : MonoBehaviour
{
    private bool gameEnded;

    public void WinLevel()
    {
        if (!gameEnded)
        {
            SceneManager.LoadScene("WinScene");
            gameEnded = true;
        }
    }

    public void LooseLevel()
    {
        if (!gameEnded)
        {
            SceneManager.LoadScene("LoseScene");
            gameEnded = true;
        }
    }
}
