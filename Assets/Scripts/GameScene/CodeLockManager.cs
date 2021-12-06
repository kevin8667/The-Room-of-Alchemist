using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLockManager : MonoBehaviour
{
    public bool _isUnlocked;

    [SerializeField] string _unlockedSpriteName;
    [SerializeField] GameObject _lockerSprite;

    [SerializeField] private CodeLock _lock1, _lock2, _lock3, _lock4;

    [SerializeField] private GameObject _objectInsideLocker;

    [SerializeField] private GameObject _lockObj2, _lockObj4;

    [SerializeField] AudioClip _solvingSFX;

    private Inventory _inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if ( _isUnlocked == false)
            {
                _isUnlocked = true;
                if (_solvingSFX != null)
                {
                    AudioHelper.PlayClip2D(_solvingSFX, 1f);
                }

                _lockObj2.transform.GetChild(2).gameObject.SetActive(false);

                _lockObj4.transform.GetChild(0).gameObject.SetActive(false);

                _lockerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _unlockedSpriteName);
                _objectInsideLocker.SetActive(true);
            }
        }
        if (_lock1._isOpened && _lock2._isOpened && _lock3._isOpened && _lock4._isOpened && _isUnlocked == false)
        {
            _isUnlocked = true;
            if (_solvingSFX != null)
            {
                AudioHelper.PlayClip2D(_solvingSFX, 1f);
            }

            _lockObj2.transform.GetChild(2).gameObject.SetActive(false);

            _lockObj4.transform.GetChild(0).gameObject.SetActive(false);

            _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

            foreach (Transform slot in _inventory._slots.transform)
            {
                if (slot.gameObject == _inventory._currentSelectedSlot && (slot.GetComponent<Slot>().ItemProperty == Slot.property.usable || slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable) && slot.transform.GetChild(0).GetComponent<Image>().sprite.name != "EmptyItem")
                {
                    if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "Code")
                    {

                        slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                    }
                }
            }

            _lockerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _unlockedSpriteName);
            _objectInsideLocker.SetActive(true);
        }
        
    }
}
