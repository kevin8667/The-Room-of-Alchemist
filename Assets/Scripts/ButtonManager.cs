using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public static event Action<int> ObjectResume;
    public static event Action LinkedViewPointEnable;

    private ImageDisplay _currentDisplay;

    

    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("ImageDisplay").GetComponent<ImageDisplay>();
        
    }

    public void OnRightButtonClicked() 
    {
        _currentDisplay.CurrentWall -= 1;
    }

    public void OnLeftButtonClicked()
    {
        _currentDisplay.CurrentWall += 1;
    }

    public void OnReturnButtonClicked()
    {
        Debug.Log(_currentDisplay.GetComponent<SpriteRenderer>().sprite.name);
        if (_currentDisplay.CurrentState == ImageDisplay.State.ChangedView) 
        {
            Debug.Log(_currentDisplay.CurrentState);

            if (_currentDisplay.RoomsState == ImageDisplay.State.StudyRoom)
            {
                _currentDisplay.CurrentState = ImageDisplay.State.StudyRoom;
            }else if (_currentDisplay.RoomsState == ImageDisplay.State.ExperimentRoom)
            {
                _currentDisplay.CurrentState = ImageDisplay.State.ExperimentRoom;
            }

            

            _currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + _currentDisplay.CurrentWall.ToString());
            ObjectResume?.Invoke(_currentDisplay.CurrentWall);
            
            GameObject[] _gameObjects = GameObject.FindGameObjectsWithTag("ObjectsInside");
            foreach (GameObject gameObject in _gameObjects)
            {
                foreach (Transform child in gameObject.transform)
                {

                    child.gameObject.SetActive(false);
                }
            }
            Debug.Log(_currentDisplay.CurrentState);

        }
        else if(_currentDisplay.CurrentState == ImageDisplay.State.ChangedView_2)
        {
            

            _currentDisplay.CurrentState = _currentDisplay.PreviousState;
            _currentDisplay.GetComponent<SpriteRenderer>().sprite = _currentDisplay._previousSprite;

            LinkedViewPointEnable?.Invoke();

            /**GameObject[] _gameObjects = GameObject.FindGameObjectsWithTag("ChangedViewObjects");
            foreach (GameObject gameObject in _gameObjects)
            {
                foreach (Transform child in gameObject.transform)
                {
                    BoxCollider2D newCollider = child.GetComponent<BoxCollider2D>();
                    if (newCollider != null)
                    {
                        newCollider.enabled = true;
                    }
                }
            }**/

            GameObject[] _gameObjectsInside = GameObject.FindGameObjectsWithTag("ObjectsInside");
            foreach (GameObject gameObject in _gameObjectsInside)
            {
                foreach (Transform child in gameObject.transform)
                {

                    child.gameObject.SetActive(false);
                }
            }
        }

        
        

    }

    // Update is called once per frame
    void Update()
    {
    }
}
