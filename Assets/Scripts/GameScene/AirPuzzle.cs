using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] string[] _correctItems;

    private bool _isMineralAdded;
    private bool _isLiquidAdded;

    private GameObject _inventory;

    private bool _isSolved;

    [SerializeField] private bool _isGiveItem;


    public string _displaySprite;
    public enum property { usable, displayable, reusable };

    public string DisplayImage;



    public property ItemProperty;

    private GameObject _inventorySlots;



    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
        _isMineralAdded = false;
        _isLiquidAdded = false;
        _isSolved = false;

    }

    public void Interact(ImageDisplay currentDisplay)
    {
        foreach (string str in _correctItems)
        {
            if (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == str && _isSolved == false)
            {
                switch (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name)
                {
                    case "AirLiquid":
                        if (_isLiquidAdded == false && _isMineralAdded == false)
                        {
                            _isLiquidAdded = true;
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/AirPuzzleBoxWithLiquid");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");

                        }
                        else if(_isLiquidAdded == false && _isMineralAdded == true)
                        {
                            _isLiquidAdded = true;
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/AirPuzzleBoxUnlocked");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _isSolved = true;
                        }
                    
                        break;
                    case "AirMineral":
                        if (_isLiquidAdded == false && _isMineralAdded == false)
                        {
                            _isMineralAdded = true;
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/AirPuzzleBoxWithMineral");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");

                        }
                        else if (_isLiquidAdded == true && _isMineralAdded == false)
                        {
                            _isMineralAdded = true;
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/AirPuzzleBoxUnlocked");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _isSolved = true;
                        }
                        break;
                }
            }

        }

        if (_isGiveItem && _isSolved)
        {
            ItemPickUp();
            _isGiveItem = false;
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
