using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageDisplay : MonoBehaviour
{
    public static event Action<int, int> ObjectSwitch;

    public enum State 
    {
        StudyRoom, ExperimentRoom, Zoom, ChangedView, ChangedView_2
    };

    public State CurrentState { get; set; }

    public State PreviousState { get; set; }

    public State RoomsState { get; set; }

    private int _currentWall;
    private int _previousWall;

    public Sprite _previousSprite;

    [SerializeField] private MagicCircle _magicCircle;

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
            if(_magicCircle._isMagicEnabled && _currentWall == 2)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Wall2Changed");
            }
            ObjectSwitch?.Invoke(_currentWall, _previousWall);
            
        }

        if(CurrentState == State.ChangedView)
        {
            _previousSprite = GetComponent<SpriteRenderer>().sprite;
        }

        if (CurrentState == State.ExperimentRoom) 
        {
            RoomsState = State.ExperimentRoom;
        }else if (CurrentState == State.StudyRoom)
        {
            RoomsState = State.StudyRoom;
        }

        _previousWall = _currentWall;
    }



}
