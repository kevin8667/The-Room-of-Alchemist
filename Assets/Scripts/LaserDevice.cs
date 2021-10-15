using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserDevice : MonoBehaviour, IInteractable
{
    [SerializeField] string _correctItem;

    [SerializeField] private string _tragetSpriteName;

    [SerializeField] GameObject _affectedObject;

    [SerializeField] private string _affectedTragetSpriteName;

    [SerializeField] private GameObject[] _laserBeams;

    private GameObject _inventory;

    private bool _isSolved;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    public void Interact(ImageDisplay currentDisplay)
    {
        if (_inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == _correctItem && _isSolved == false)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _tragetSpriteName);
            _isSolved = true;
            if (_affectedObject && _isSolved)
            {
                _affectedObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _affectedTragetSpriteName);
            }
            _inventory.GetComponent<Inventory>()._currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/EmptyItem");

            foreach (GameObject gameObject in _laserBeams)
            {
                gameObject.gameObject.SetActive(true);
            }

        }
        
    }

   

    // Update is called once per frame
    void Update()
    {

    }
}
