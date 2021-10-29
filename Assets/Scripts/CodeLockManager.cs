using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockManager : MonoBehaviour
{
    public bool _isUnlocked;

    [SerializeField] string _unlockedSpriteName;
    [SerializeField] GameObject _lockerSprite;

    [SerializeField] private CodeLock _lock1, _lock2, _lock3, _lock4;

    [SerializeField] private GameObject _objectInsideLocker;

    [SerializeField] private GameObject _linkViewPoint;

    // Update is called once per frame
    void Update()
    {
        if (_lock1._isOpened && _lock2._isOpened && _lock3._isOpened && _lock4._isOpened && _isUnlocked == false)
        {
            _isUnlocked = true;

            _lockerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _unlockedSpriteName);
            _objectInsideLocker.SetActive(true);
        }
        
    }
}
