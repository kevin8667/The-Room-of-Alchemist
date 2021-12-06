using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterComponent : MonoBehaviour, IInteractable
{
    [SerializeField] string _correctItem;


    private GameObject _inventory;

    private bool _isSolved;

    [SerializeField] private bool _isGiveItem;


    public string _displaySprite;
    public enum property { usable, displayable, reusable };

    public string DisplayImage;

    [SerializeField] AudioClip _solvedSFX;

    public property ItemProperty;

    private GameObject _inventorySlots;

    GameSceneManager _gameSceneManager;

    [SerializeField] string _dialog;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
        _gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();

    }

    public void Interact(ImageDisplay currentDisplay)
    {
        if (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == _correctItem && _isSolved == false)
        {
            if (_solvedSFX != null)
            {
                AudioHelper.PlayClip2D(_solvedSFX, 1f);
            }
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/WaterComponentSolved");
            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
            _isSolved = true;
            
        }
        else if (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name != _correctItem && _isSolved == false)
        {
            
        }
        else if (_isGiveItem && _isSolved)
        {
            ItemPickUp();
            Destroy(gameObject);
            Destroy(GameObject.Find("WaterComponent_FarView"));
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

