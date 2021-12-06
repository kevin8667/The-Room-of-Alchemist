using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] Sprite[] _images;

    Image _thisImage;

    bool _isChanged = true;


    // Start is called before the first frame update
    void Start()
    {
        _thisImage = gameObject.GetComponent<Image>();
        _thisImage.sprite = _images[Random.Range(0, _images.Length)];


    }

    // Update is called once per frame
    void Update()
    {
       
 
    }
}
