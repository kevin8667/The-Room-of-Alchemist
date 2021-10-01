using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour, IInteractable
{
    [SerializeField] string _correctItem;

    [SerializeField] private string _tragetSpriteName;

    [SerializeField] bool _isOtherAffected;

    [SerializeField] string _affectedName;

    [SerializeField] string _affectedTragetSpriteName;

    private GameObject _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void Interact (ImageDisplay currentDisplay)
    {
        if(_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == _correctItem)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _tragetSpriteName);
            if (_isOtherAffected)
            {
                GameObject.Find(_affectedName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _affectedTragetSpriteName);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
