using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField] GameObject[] _elementalSlots;

    [SerializeField] GameObject _escape;

    private bool _air, _fire, _earth, _water;

    public bool _isMagicEnabled;

    [SerializeField] AudioClip _doorSFX;

    // Start is called before the first frame update
    void Start()
    {
        _isMagicEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject gameObject in _elementalSlots)
        {
            if(gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                if(gameObject.GetComponent<SpriteRenderer>().sprite.name == "AirObjectTop")
                {
                    _air = true;
                }
                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "FireObjectTop")
                {
                    _fire = true;
                }
                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "EarthObjectTop")
                {
                    _earth = true;
                }
                if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "WaterObjectTop")
                {
                    _water = true;
                }
            }
        }

        if(_air && _fire && _earth && _water && _isMagicEnabled == false)
        {
            if (_doorSFX != null)
            {
                AudioHelper.PlayClip2D(_doorSFX, 1f);
            }
            _isMagicEnabled = true;
            _escape.SetActive(true);
        }
    }
}
