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
        else if(_isSolved == false)
        {
            _gameSceneManager.DisplayDialog(_dialog);
        }
        
    }

   

    // Update is called once per frame
    void Update()
    {

    }
}
