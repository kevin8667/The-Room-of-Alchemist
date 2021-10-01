using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageDisplay : MonoBehaviour
{
    public static event Action<int, int> ObjectSwitch;


    public enum State 
    {
        StudyRoom, ExperimentRoom, Zoom, ChangedView
    };

    public State CurrentState { get; set; }

    public State PreviousState { get; set; }

    private int _currentWall;
    private int _previousWall;

    public int CurrentWall 
    {
        get { return _currentWall; }
        set
        {
            if (CurrentState == State.StudyRoom)
            {
                if (value == 5)
                {
                    _currentWall = 1;
                }
                else if (value == 0)
                {
                    _currentWall = 4;
                }
                else
                {
                    _currentWall = value;
                }
            }
            else 
            {
                if (value == 9)
                {
                    _currentWall = 5;
                }
                else if (value == 4)
                {
                    _currentWall = 8;
                }
                else
                {
                    _currentWall = value;
                }
            }

            
        }
    }

    private void Start()
    {
        _previousWall = 0;
        _currentWall = 1;
        CurrentState = State.StudyRoom;
        PreviousState = CurrentState;
    }

    private void Update()
    {
        if(_currentWall != _previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + _currentWall.ToString());
            ObjectSwitch?.Invoke(_currentWall, _previousWall);
            
        }
        
        _previousWall = _currentWall;
    }



}
