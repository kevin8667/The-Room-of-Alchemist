using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensDevice : MonoBehaviour, IInteractable
{
    private Sprite _previousSprite;

    [SerializeField] private string _targetSpriteName;

    public int _currentLens = 1;

    private LaserChanger _laserLight;

    public void Interact(ImageDisplay currentDisplay)
    {
        if(_laserLight._isWhiteLight == false)
        {
            if (_currentLens == 1)
            {
                _currentLens += 1;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _targetSpriteName);

            }
            else if (_currentLens == 2)
            {
                _currentLens = 1;
                GetComponent<SpriteRenderer>().sprite = _previousSprite;
            }
        }
       



    }
    // Start is called before the first frame update
    void Start()
    {
        _previousSprite = GetComponent<SpriteRenderer>().sprite;
        _laserLight = GameObject.Find("LaserChanger").GetComponent<LaserChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
