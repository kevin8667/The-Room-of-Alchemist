using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLock : MonoBehaviour
{
    public GameObject[] _buttonList;
    private int _swicthedButton, _nonSwitchedButton;
    public bool _isUnlocked;

    public GameObject _lockerSprite;

    [SerializeField] string _unlockedSpriteName;

    [SerializeField] private GameObject _objectInsideLocker;

    [SerializeField] private GameObject _linkViewPoint;

    [SerializeField] AudioClip _solivingSFX;

    // Start is called before the first frame update
    void Start()
    {

        _isUnlocked = false;

        foreach(GameObject btn in _buttonList)
        {
            int rdn = Random.Range(0, 3);

            Debug.Log(rdn);

            if (rdn == 1)
            {
                btn.GetComponent<ButtonSwitch>()._isChanged = true;
                btn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButtonPushed");
            }
            else if (rdn == 2)
            {
                btn.GetComponent<ButtonSwitch>()._isChanged = false;
                btn.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/LockButton");
            }
        }

        //CheckSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isUnlocked == false)
        {
           CheckSwitch();
        }
        
        
    }

    void CheckSwitch()
    {
        _nonSwitchedButton = 0;
        foreach (GameObject button in _buttonList)
        {
            if (button.GetComponent<ButtonSwitch>()._isChanged == false)
            {
                _nonSwitchedButton += 1;

            }
            else if (button.GetComponent<ButtonSwitch>()._isChanged == true)
            {
                _nonSwitchedButton -= 1;
            }
        }
        if (_nonSwitchedButton == 9)
        {
            Debug.Log("Unlocked!");
            _isUnlocked = true;

            if (_solivingSFX != null)
            {
                AudioHelper.PlayClip2D(_solivingSFX, 1f);
            }

            _lockerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _unlockedSpriteName);

            for (int i = 0; i < 9; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            if(_objectInsideLocker != null)
            {
                _objectInsideLocker.SetActive(true);
            }
            
            _linkViewPoint.GetComponent<ChangeView>()._isLockerUnlocked = true;
        }

    }


}
