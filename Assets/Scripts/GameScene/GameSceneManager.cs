using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{

    [SerializeField] GameObject _dialog;

    GameObject _newdialog;



    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoadEnd(string _sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }

    public void LoadTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    public void Pause(GameObject pausemenu)
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume(GameObject pausemenu)
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }


    public void DisplayDialog(string dialog)
    {
        if(GameObject.Find("Dialog(Clone)") == null)
        {
            _newdialog = Instantiate(_dialog, new Vector3(4.5f, -4.5f, 0), Quaternion.identity);
            if (_newdialog)
            {
                _newdialog.GetComponent<TextMeshPro>().text = dialog;
                Destroy(_newdialog, 2f);
            }
        }
       
    }
   

}
