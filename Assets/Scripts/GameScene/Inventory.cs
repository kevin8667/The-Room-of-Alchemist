using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject _currentSelectedSlot { get; set; }
    public GameObject _previousSelectedSlot { get; set; }

    public GameObject _itemDisplayer { get; private set; }

    public GameObject _slots;

    [SerializeField] GameObject _itemText;


    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
        _itemText.GetComponent<Text>().text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
        SelectSlot();
        HideDisplay();
        /**if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/FireObject");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/WaterObject");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EarthObject");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/AirObject");
        }**/
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/Air Liquid");
        }
        if(_currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "EmptyItem")
        {
            _itemText.SetActive(false);
        }
        else
        {
            _itemText.SetActive(true);
        }
    }

    private void InitializeInventory()
    {
        _itemDisplayer = GameObject.Find("ItemDisplayer");
        _itemDisplayer.SetActive(false);
        _slots = GameObject.Find("Slots");
        foreach(Transform slot in _slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
            slot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
        }
        _currentSelectedSlot = GameObject.Find("Slot");
        _previousSelectedSlot = _currentSelectedSlot;
    }

    void SelectSlot()
    {
        foreach (Transform slot in _slots.transform)
        {
            if (slot.gameObject == _currentSelectedSlot && (slot.GetComponent<Slot>().ItemProperty == Slot.property.usable || slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable) && slot.transform.GetChild(0).GetComponent<Image>().sprite.name != "EmptyItem")
            {
                

                slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);
                _itemText.GetComponent<Text>().text = _currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
                

            }
            else if (slot.gameObject == _currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                //slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            _itemDisplayer.SetActive(false);
            if (_currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                _currentSelectedSlot = _previousSelectedSlot;
                _previousSelectedSlot = _currentSelectedSlot;
            }
        }
    }

}
