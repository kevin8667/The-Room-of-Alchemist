using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

    }


    public void LoadTitle(string _sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }
}
