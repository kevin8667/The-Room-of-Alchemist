using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private ImageDisplay _currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("ImageDisplay").GetComponent<ImageDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 _rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D _hit = Physics2D.Raycast(_rayPosition, Vector2.zero, 100);

            if (_hit && _hit.transform.tag == "Interactable") 
            {
                Debug.Log("Door Hit");
                _hit.transform.GetComponent<IInteractable>().Interact(_currentDisplay);
                
                
            }
        }
    }
}
