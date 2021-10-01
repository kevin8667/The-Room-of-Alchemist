using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string _displaySprite;
    public enum property { usable, displayable };

    public string DisplayImage;
    public string CombinationItem;

    public property ItemProperty;

    private GameObject _inventorySlots;

    public void Interact(ImageDisplay currentDisplay)
    {
        ItemPickUp();
    }

    void Start()
    {

    }

    public void ItemPickUp()
    {
        _inventorySlots = GameObject.Find("Slots");

        foreach (Transform slot in _inventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "EmptyItem")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + _displaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)ItemProperty, DisplayImage, CombinationItem);
                Destroy(gameObject);
                break;
            }
        }
    }
}
