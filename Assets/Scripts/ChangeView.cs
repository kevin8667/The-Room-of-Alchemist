using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeView : MonoBehaviour, IInteractable
{
    public static event Action<int> ObjectDisable;
    public static event Action<GameObject[]> LinkedViewPoint;
    public static event Action LinkedViewPointDisable;

    public string _spriteName;


    [SerializeField] private GameObject[] _objectsToEnable;
    [SerializeField] private GameObject[] _viewPointToDisable;

    [SerializeField] private bool _isSecondLayer;

    



    public void Interact(ImageDisplay currentDisplay)
    {
       if (_isSecondLayer) 
        {
            currentDisplay.PreviousState = currentDisplay.CurrentState;
            currentDisplay.CurrentState = ImageDisplay.State.ChangedView_2;

            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);

            ObjectDisable?.Invoke(currentDisplay.CurrentWall);
            LinkedViewPoint?.Invoke(_viewPointToDisable);
            LinkedViewPointDisable?.Invoke();

            foreach (GameObject gameObject in _objectsToEnable)
            {
                gameObject.SetActive(true);
                BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
                if (newCollider != null)
                {
                    newCollider.enabled = true;
                }
            }

        }if (_isSecondLayer == false) 
        {
            currentDisplay.PreviousState = currentDisplay.CurrentState;
            currentDisplay.CurrentState = ImageDisplay.State.ChangedView;
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);
            Debug.Log(currentDisplay.CurrentState);

            ObjectDisable?.Invoke(currentDisplay.CurrentWall);

            foreach (GameObject gameObject in _objectsToEnable)
            {
                gameObject.SetActive(true);
                BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
                if (newCollider != null)
                {
                    newCollider.enabled = true;
                }
            }
        }

        


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
