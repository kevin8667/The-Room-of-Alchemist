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
        gameObject.layer = 2;
        currentDisplay.CurrentState = ImageDisplay.State.Zoom;
        ConstrainCamera();



    }

    private void ConstrainCamera() 
    {
        var _height = Camera.main.orthographicSize;
        var _width = _height * Camera.main.aspect;
        var _cameraBounds = GameObject.Find("CameraBounds");

        if(Camera.main.transform.position.x + _width > _cameraBounds.transform.position.x + _cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position = new Vector3(_cameraBounds.transform.position.x + _cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - 
                (Camera.main.transform.position.x + _width), 0, 0);
        }
    }

}
