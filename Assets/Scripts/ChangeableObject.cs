using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableObject : MonoBehaviour , IInteractable
{
    public string _spriteName;
    [SerializeField] private GameObject[] _objectsToEnable;

    private string _previousSprite;

    [SerializeField] private ChangeView _changeView;

    private bool _isChanged;

    [SerializeField] private bool _isSwitchable;

    public void Interact(ImageDisplay currentDisplay)
    {
        if(_isSwitchable && _isChanged == false)
        {
            _previousSprite = _changeView._spriteName;
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);
            foreach (GameObject gameObject in _objectsToEnable)
            {
                gameObject.SetActive(true);
                BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
                if (newCollider != null)
                {
                    newCollider.enabled = true;
                }
            }
            _isChanged = true;
        }else if (_isSwitchable && _isChanged)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _previousSprite);
            Debug.Log(_isChanged);
            foreach (GameObject gameObject in _objectsToEnable)
            {
                gameObject.SetActive(true);
                BoxCollider2D newCollider = gameObject.GetComponent<BoxCollider2D>();
                if (newCollider != null)
                {
                    newCollider.enabled = false;
                }
            }
            
        }else if (_isSwitchable == false && _isChanged == false)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _spriteName);
            Debug.Log(_isChanged);
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
        _isChanged = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ImageDisplay").GetComponent<ImageDisplay>().GetComponent<SpriteRenderer>().sprite.name != _spriteName) 
        {
            _isChanged = false;
        }
    }
}
