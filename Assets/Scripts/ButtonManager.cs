using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour
{
    public static event Action<int> ObjectResume;

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
        _currentDisplay.CurrentState = _currentDisplay.PreviousState;
        
        _currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + _currentDisplay.CurrentWall.ToString());
        ObjectResume?.Invoke(_currentDisplay.CurrentWall);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
