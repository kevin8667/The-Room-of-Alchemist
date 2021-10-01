using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject _currentSelectedSlot { get; set; }
    public GameObject _previousSelectedSlot { get; set; }

    

    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeInventory()
    {
        var slots = GameObject.Find("Slots");
        foreach(Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");
        }
    }
}
