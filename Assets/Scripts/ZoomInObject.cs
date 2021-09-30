using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    protected float _zoomFactor = 0.5f;

    public void Interact(ImageDisplay currentDisplay) 
    {
        Camera.main.orthographicSize *= _zoomFactor;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
