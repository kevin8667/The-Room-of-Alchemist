using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("backspace"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoadEnd(string _sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }
}
