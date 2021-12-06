using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeakerStand : MonoBehaviour, IInteractable
{
    [SerializeField] string[] _correctItems;

    private int _r;
    private int _g; 
    private int _b;

    private bool _isBeakerOn;

    private GameObject _inventory;

    private bool _isSolved;

    [SerializeField] private bool _isGiveItem;


    public string _displaySprite;
    public enum property { usable, displayable, reusable };

    public string DisplayImage;

    [SerializeField] AudioClip _liquidSFX;

    public property ItemProperty;

    private GameObject _inventorySlots;



    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
        _r = 0;
        _g = 0;
        _b = 0;

    }

    public void Interact(ImageDisplay currentDisplay)
    {
        foreach(string str in _correctItems)
        {
            if (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == str && _isSolved == false)
            {
                switch (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name)
                {
                    case "Empty Beaker":
                        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_Empty");
                        GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_Empty");
                        _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                        _isBeakerOn = true;
                        break;
                    case "Red Potion":
                        if(_r == 0 && _g == 0 && _b ==0 && _isBeakerOn) 
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_R");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_R");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _r += 1;
                        }
                        else if (_r == 0 && _g == 1 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RG");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RG");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _r += 1;
                        }
                        else if (_r == 0 && _g == 0 && _b == 1 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RB");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RB");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _r += 1;
                        }
                        else if (_r == 0 && _g == 1 && _b == 1 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RGB");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RGB");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _r += 1;
                            _isSolved = true;
                        }
                        break;
                    case "Blue Potion":
                        if (_r == 0 && _g == 0 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_B");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_B");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _b += 1;
                        }
                        else if (_r == 0 && _g == 1 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_BG");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_BG");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _b += 1;
                        }
                        else if (_r == 1 && _g == 0 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RB");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RB");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _b += 1;
                        }
                        else if (_r == 1 && _g == 1 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RGB");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RGB");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _b += 1;
                            _isSolved = true;
                        }
                        break;
                    case "Green Potion":
                        if (_r == 0 && _g == 0 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_G");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_G");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _g += 1;
                        }
                        else if (_r == 0 && _g == 0 && _b == 1 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_BG");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_BG");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _g += 1;
                        }
                        else if (_r == 1 && _g == 0 && _b == 0 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RG");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RG");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _g += 1;
                        }
                        else if (_r == 1 && _g == 0 && _b == 1 && _isBeakerOn)
                        {
                            if (_liquidSFX != null)
                            {
                                AudioHelper.PlayClip2D(_liquidSFX, 1f);
                            }
                            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RGB");
                            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand_RGB");
                            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
                            _g += 1;
                            _isSolved = true;
                        }
                        break;
                }
            }
            
        }

        if (_isGiveItem && _isSolved)
        {
            ItemPickUp();
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand");
            GameObject.Find("BeakerStand_FarView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BeakerStand" +
                "");
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
