using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "MainMenu";

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
