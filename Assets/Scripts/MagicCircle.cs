using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField] GameObject[] _elementalSlots;
    [SerializeField] GameObject _escape;

    private int _elementalPower;

    public bool _isMagicEnabled;

    // Start is called before the first frame update
    void Start()
    {
        _elementalPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject gameObject in _elementalSlots)
        {
            if(gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                _elementalPower += 1;
            }
        }

        if(_elementalPower == 4)
        {
            _isMagicEnabled = true;
            _escape.SetActive(true);
        }
    }
}
