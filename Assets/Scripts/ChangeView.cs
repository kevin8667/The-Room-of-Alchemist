using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeView : MonoBehaviour, IInteractable
{
    public static event Action<int> ObjectDisable;

    [SerializeField] private string _spriteName;
    [SerializeField] private GameObject[] _objectsToEnable;

    public void Interact(ImageDisplay currentDisplay)
    {
        currentDisplay.PreviousState = currentDisplay.CurrentState;
        currentDisplay.CurrentState = ImageDisplay.State.ChangedView;
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);

        ObjectDisable?.Invoke(currentDisplay.CurrentWall);
        foreach (GameObject gameObject in _objectsToEnable)
        {
            BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
            if (newCollider != null)
            {
                newCollider.enabled = true;
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
