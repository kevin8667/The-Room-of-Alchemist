using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FakeDoor : MonoBehaviour, IInteractable
{
    public static event Action<int> ObjectDisable;
    public static event Action<GameObject[]> LinkedViewPoint;
    public static event Action LinkedViewPointDisable;

    public string _spriteName;


    [SerializeField] private GameObject[] _objectsToEnable;
    [SerializeField] private GameObject[] _viewPointToDisable;

    [SerializeField] private bool _isSecondLayer;

    [SerializeField] private GameObject _objectInLocker;

    [SerializeField] private GameObject _blackLock;

    [SerializeField] private AudioClip _lockedSFX;

    [SerializeField] private AudioClip _unlockedSFX;

    public bool _isLockerUnlocked;



    public void Interact(ImageDisplay currentDisplay)
    {
        if (_isSecondLayer)
        {
            if(_blackLock.GetComponent<SpriteRenderer>().sprite.name == "BlackLockUnlocked")
            {
                if (_unlockedSFX != null)
                {
                    AudioHelper.PlayClip2D(_unlockedSFX, 1f);
                }

                currentDisplay.PreviousState = currentDisplay.CurrentState;
                currentDisplay.CurrentState = ImageDisplay.State.ChangedView_2;

                currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);

                ObjectDisable?.Invoke(currentDisplay.CurrentWall);
                LinkedViewPoint?.Invoke(_viewPointToDisable);
                LinkedViewPointDisable?.Invoke();

                if (_objectsToEnable != null)
                {
                    foreach (GameObject gameObject in _objectsToEnable)
                    {
                        gameObject.SetActive(true);
                        BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
                        if (newCollider != null)
                        {
                            newCollider.enabled = true;
                        }
                        SpriteRenderer newSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                        if (newSpriteRenderer != null)
                        {
                            newSpriteRenderer.enabled = true;
                        }
                    }
                }
            }else if (_blackLock.GetComponent<SpriteRenderer>().sprite.name != "BlackLockUnlocked")
            {
                if (_lockedSFX != null)
                {
                    AudioHelper.PlayClip2D(_lockedSFX, 1f);
                }
            }
            

        }
        if (_isSecondLayer == false)
        {
            currentDisplay.PreviousState = currentDisplay.CurrentState;
            currentDisplay.CurrentState = ImageDisplay.State.ChangedView;
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);
            Debug.Log(currentDisplay.CurrentState);

            ObjectDisable?.Invoke(currentDisplay.CurrentWall);

            if (_objectsToEnable != null)
            {

                foreach (GameObject gameObject in _objectsToEnable)
                {
                    gameObject.SetActive(true);
                    BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
                    if (newCollider != null)
                    {
                        newCollider.enabled = true;
                    }
                    SpriteRenderer newSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    if (newSpriteRenderer != null)
                    {
                        newSpriteRenderer.enabled = true;
                    }
                }

            }

        }

        if (_isLockerUnlocked)
        {
            _objectInLocker.SetActive(true);
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
