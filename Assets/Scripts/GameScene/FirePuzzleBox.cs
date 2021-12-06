using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePuzzleBox : MonoBehaviour
{
    private LaserChanger _laserLight;

    public string _displaySprite;
    public enum property { usable, displayable };

    public string DisplayImage;


    private bool _isOpened;

    public property ItemProperty;

    private GameObject _inventorySlots;

    [SerializeField] AudioClip _solvingSFX;

    // Start is called before the first frame update
    void Start()
    {
        _laserLight = GameObject.Find("LaserChanger").GetComponent<LaserChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_laserLight._isWhiteLight && _isOpened == false)
        {
            if (_solvingSFX != null)
            {
                AudioHelper.PlayClip2D(_solvingSFX, 1f);
            }
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "FirePuzzleBoxUnlocked");
            ItemPickUp();
            _isOpened = true;
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
