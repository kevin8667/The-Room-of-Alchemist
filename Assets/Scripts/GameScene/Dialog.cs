using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialog : MonoBehaviour, IInteractable
{
    GameSceneManager _gameManager;

    [SerializeField] string _dialog;

    //public bool _isDisplayed = false;

    private void Start()
    {
        _gameManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();

        
    }

    public void Interact(ImageDisplay currentDisplay)
    {
        _gameManager.DisplayDialog(_dialog);

    }

}
