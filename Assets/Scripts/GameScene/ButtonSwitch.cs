using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour, IInteractable
{
    public bool _isChanged;
    
    private GameObject[] _buttonList;
    
    [SerializeField] private int _affectedButton_1, _affectedButton_2, _affectedButton_3, _affectedButton_4;

    [SerializeField] AudioClip _buttonSFX;


    // Start is called before the first frame update
    void Start()
    {
        _buttonList = GameObject.Find("ButtonLock").GetComponent<ButtonLock>()._buttonList;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact(ImageDisplay currentDisplay)
    {
        if(_buttonSFX != null)
        {
            AudioHelper.PlayClip2D(_buttonSFX,1f);
        }
        SwicthColor();
    }


    public void SwicthColor()
    {
        if (GameObject.Find("ButtonLock").GetComponent<ButtonLock>()._isUnlocked == false) 
        {
            if (_isChanged == false)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButtonPushed");
                _isChanged = true;
                if (_affectedButton_3 != 0 && _affectedButton_4 == 0)
                {
                    SwitchOther(_affectedButton_1, _affectedButton_2, _affectedButton_3);
                }
                else if (_affectedButton_4 != 0)
                {
                    SwitchOther(_affectedButton_1, _affectedButton_2, _affectedButton_3, _affectedButton_4);
                }
                else
                {
                    SwitchOther(_affectedButton_1, _affectedButton_2);
                }
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButton");
                _isChanged = false;
                if (_affectedButton_3 != 0 && _affectedButton_4 == 0)
                {
                    SwitchOther(_affectedButton_1, _affectedButton_2, _affectedButton_3);
                }
                else if (_affectedButton_4 != 0)
                {
                    SwitchOther(_affectedButton_1, _affectedButton_2, _affectedButton_3, _affectedButton_4);
                }
                else
                {
                    SwitchOther(_affectedButton_1, _affectedButton_2);
                }
            }
        }
        

        
    }

    public void SwitchOther(int _bt1, int _bt2)
    {
        if(_buttonList[_bt1-1].GetComponent<ButtonSwitch>()._isChanged == false)
        {
            _buttonList[_bt1 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButtonPushed");
            _buttonList[_bt1 - 1].GetComponent<ButtonSwitch>()._isChanged = true;
        }
        else
        {
            _buttonList[_bt1 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButton");
            _buttonList[_bt1 - 1].GetComponent<ButtonSwitch>()._isChanged = false;
        }

        if (_buttonList[_bt2 - 1].GetComponent<ButtonSwitch>()._isChanged == false)
        {
            _buttonList[_bt2 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButtonPushed");
            _buttonList[_bt2 - 1].GetComponent<ButtonSwitch>()._isChanged = true;
        }
        else
        {
            _buttonList[_bt2 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButton");
            _buttonList[_bt2 - 1].GetComponent<ButtonSwitch>()._isChanged = false;
        }
    }
    public void SwitchOther(int _bt1, int _bt2, int _bt3)
    {
        SwitchOther(_bt1,_bt2);
       
        if (_buttonList[_bt3 - 1].GetComponent<ButtonSwitch>()._isChanged == false)
        {
            _buttonList[_bt3 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButtonPushed");
            _buttonList[_bt3 - 1].GetComponent<ButtonSwitch>()._isChanged = true;
        }
        else
        {
            _buttonList[_bt3 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButton");
            _buttonList[_bt3 - 1].GetComponent<ButtonSwitch>()._isChanged = false;
        }
    }

    public void SwitchOther(int _bt1, int _bt2, int _bt3, int _bt4)
    {
        SwitchOther(_bt1,_bt2, _bt3);

        if (_buttonList[_bt4 - 1].GetComponent<ButtonSwitch>()._isChanged == false)
        {
            _buttonList[_bt4 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButtonPushed");
            _buttonList[_bt4 - 1].GetComponent<ButtonSwitch>()._isChanged = true;
        }
        else
        {
            _buttonList[_bt4 - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButton");
            _buttonList[_bt4 - 1].GetComponent<ButtonSwitch>()._isChanged = false;
        }
    }

}
