using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
   public void ExitGame()
    {
        Application.Quit();
        
    }


    public void LoadGame(string _sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }
}
