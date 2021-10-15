using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour, IInteractable
{
    [SerializeField] string _correctItem;

    [SerializeField] private string _tragetSpriteName;

    [SerializeField] GameObject _affectedObject;

    [SerializeField] string _affectedTragetSpriteName;

    private GameObject _inventory;

    private bool _isSolved;

    [SerializeField] private bool _isGiveItem;


    public string _displaySprite;
    public enum property { usable, displayable, reusable };

    public string DisplayImage;

    [SerializeField] private bool _isTurnOff;

    public property ItemProperty;

    private GameObject _inventorySlots;



    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void Interact (ImageDisplay currentDisplay)
    {
        if(_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == _correctItem && _isSolved == false)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _tragetSpriteName);
            _isSolved = true;
            if (_affectedObject && _isSolved)
            {
                _affectedObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _affectedTragetSpriteName);
            }
            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");

            if (_isGiveItem && _isTurnOff)
            {
                ItemPickUp();
                gameObject.SetActive(false);
            }else if (_isGiveItem)
            {
                ItemPickUp();
            }
        }

    }

    public void ItemPickUp()
    {
        _inventorySlots = GameObject.Find("Slots");

        foreach (Transform slot in _inventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "EmptyItem")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + _displaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)ItemProperty, DisplayImage);
                break;
            }
        }
    }
}
