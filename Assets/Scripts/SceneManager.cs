using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private ImageDisplay _currentDisplay;
    private GameObject[] _gameObjects;

    private void Awake()
    {
        _currentDisplay = GameObject.Find("ImageDisplay").GetComponent<ImageDisplay>();
    }

    private void OnEnable()
    {
        ImageDisplay.ObjectSwitch += OnObejectEnable;
    }

    private void OnDisable()
    {
        ImageDisplay.ObjectSwitch -= OnObejectEnable;
    }



    private void OnObejectEnable(int currentWallNumber, int previousWallNumber)
    {
        if (previousWallNumber != 0) 
        {
            switch (_currentDisplay.CurrentWall)
            {
                case 1:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 1 Enabled");
                    break;
                case 2:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 2 Enabled");
                    break;
                case 3:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 3 Enabled");
                    break;
                case 4:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 4 Enabled");
                    break;
                case 5:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 5 Enabled");
                    break;
                case 6:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 6 Enabled");
                    break;
                case 7:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 7 Enabled");
                    break;
                case 8:
                    EnableObjects(currentWallNumber, previousWallNumber);
                    Debug.Log("Wall 8 Enabled");
                    break;
            }
        }

        
    }

    private void EnableObjects(int currentWallNumber, int previousWallNumber) 
    {
        _gameObjects = GameObject.FindGameObjectsWithTag("Wall" + currentWallNumber.ToString()+ "Objects");
        foreach (GameObject gameObject in _gameObjects)
        {
            foreach (Transform child in gameObject.transform)
            {
                BoxCollider2D _newcollider = child.GetComponent<BoxCollider2D>();
                if (_newcollider != null)
                {
                    _newcollider.enabled = true;
                }
            }
        }
        _gameObjects = GameObject.FindGameObjectsWithTag("Wall" + previousWallNumber.ToString() + "Objects");
        foreach (GameObject gameObject in _gameObjects)
        {
            foreach (Transform child in gameObject.transform)
            {
                BoxCollider2D _newcollider = child.GetComponent<BoxCollider2D>();
                if (_newcollider != null)
                {
                    _newcollider.enabled = false;
                }
            }
        }
    }

}
