using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject _inventory;
    public enum property { usable, displayable, empty };
    public property ItemProperty { get; set; }

    private string _displayImage;
    public string _combinationItem { get; private set; }

    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _inventory.GetComponent<Inventory>()._previousSelectedSlot = _inventory.GetComponent<Inventory>()._currentSelectedSlot;
        _inventory.GetComponent<Inventory>()._currentSelectedSlot = this.gameObject;
        //Combine();
        if (ItemProperty == Slot.property.displayable) 
        {
            DisplayItem(); 
        }
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this._displayImage = displayImage;
    }

    public void DisplayItem()
    {
        _inventory.GetComponent<Inventory>()._itemDisplayer.SetActive(true);
        _inventory.GetComponent<Inventory>()._itemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Items/" + _displayImage);
    }

    /**void Combine()
    {
        if (_inventory.GetComponent<Inventory>()._previousSelectedSlot.GetComponent<Slot>().combinationItem
            == this.gameObject.GetComponent<Slot>()._combinationItem && this.gameObject.GetComponent<Slot>()._combinationItem != "")
        {
            Debug.Log("combine");
            GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + _combinationItem));
            combinedItem.GetComponent<PickUpItem>().ItemPickUp();

            _inventory.GetComponent<Inventory>()._previousSelectedSlot.GetComponent<Slot>().ClearSlot();
            ClearSlot();
        }
    }**/

    public void ClearSlot()
    {
        ItemProperty = Slot.property.empty;
        _displayImage = "";
        _combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
    }


}
