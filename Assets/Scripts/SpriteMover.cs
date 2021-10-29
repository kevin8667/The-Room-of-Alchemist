using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour, IInteractable
{
    public float _xMovement;
    public float _otherMovement_1, _otherMovement_2;
    float _newTransform_1_X, _newTransform_2_X;

    public GameObject _otherObj_1, _otherObj_2;

    private Vector2 _thisPosition;

    private HorseBox _horseBox;

    public int _thisMovement;
    public int _thisMovementAdd, _otherObjMovement1Add, _otherObjMovement2Add;

    private void OnEnable()
    {
        _thisMovement = 0;
    }

    private void Awake()
    {
        _thisPosition = transform.position;
        _newTransform_1_X = _otherObj_1.gameObject.transform.position.x;
        _newTransform_2_X = _otherObj_2.gameObject.transform.position.x;
        _horseBox = GameObject.Find("HorseBox").GetComponent<HorseBox>();
        
    }

    private void Update()
    {
        _newTransform_1_X = _otherObj_1.gameObject.transform.position.x;
        _newTransform_2_X = _otherObj_2.gameObject.transform.position.x;
    }

    public void Interact(ImageDisplay currentDisplay)
    {
        Debug.Log((float)transform.position.x);
        Move();
    }

    public void Move()
    {
        if (_newTransform_1_X > -3.3 && _newTransform_2_X > -3.3 && _thisPosition.x > -3.3 && _horseBox._isUnlocked == false) 
        {
            
            _thisPosition = transform.position;

            _thisPosition.x += _xMovement;
            _newTransform_1_X = _otherObj_1.gameObject.transform.position.x;
            _newTransform_2_X = _otherObj_2.gameObject.transform.position.x;

            _newTransform_1_X += _otherMovement_1;
            _newTransform_2_X += _otherMovement_2;

            gameObject.transform.position = new Vector3(_thisPosition.x, gameObject.transform.position.y, 0);
            _otherObj_1.transform.position = new Vector3(_newTransform_1_X, _otherObj_1.gameObject.transform.position.y,0);
            _otherObj_2.transform.position = new Vector3(_newTransform_2_X, _otherObj_2.gameObject.transform.position.y,0);

            _thisMovement += _thisMovementAdd;
            _otherObj_1.GetComponent<SpriteMover>()._thisMovement += _otherObjMovement1Add;
            _otherObj_2.GetComponent<SpriteMover>()._thisMovement += _otherObjMovement2Add;

        }
        if (_horseBox._isUnlocked == false && _thisMovement == 18 && _otherObj_1.GetComponent<SpriteMover>()._thisMovement == 18 && _otherObj_2.GetComponent<SpriteMover>()._thisMovement == 18)
        {
            _horseBox._isUnlocked = true;
        }
    }
}
