using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserChanger : MonoBehaviour
{
    [SerializeField] private LensDevice _lens1;
    [SerializeField] private LensDevice _lens2;

    [SerializeField] private GameObject _laser1;
    [SerializeField] private GameObject _laser2;

    public bool _isWhiteLight;

    // Start is calcled before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_lens1._currentLens == 1)
        {
            _laser1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "LaserBeam_R");
        }else if(_lens1._currentLens == 2)
        {
            _laser1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "LaserBeam_Ma");
        }

        if (_lens1._currentLens == 1 && _lens2._currentLens == 1)
        {
            _laser2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "LaserBeam_O");
        }else if (_lens1._currentLens == 1 && _lens2._currentLens == 2)
        {
            _laser2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "LaserBeam_Y");
        }else if (_lens1._currentLens == 2 && _lens2._currentLens == 1)
        {
            _laser2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "LaserBeam_W");
            _isWhiteLight = true;
        }
        else if (_lens1._currentLens == 2 && _lens2._currentLens == 2)
        {
            _laser2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + "LaserBeam_M");
        }
    }
}
