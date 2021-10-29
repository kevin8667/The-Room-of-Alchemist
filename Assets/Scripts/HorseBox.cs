using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseBox : MonoBehaviour
{
    //[SerializeField] GameObject _horses1, _horses2, _horses3;

    public bool _isUnlocked;

    [SerializeField] GameObject _itemToEnable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isUnlocked == true)
        {
            
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/HorseBoxOpened");
            _itemToEnable.SetActive(true);
        }

        
    }
}
