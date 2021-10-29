using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "TutMenu";

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
