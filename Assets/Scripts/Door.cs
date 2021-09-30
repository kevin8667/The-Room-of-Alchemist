using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IInteractable
{
    public void Interact(ImageDisplay currentDisplay)
    {
        if (currentDisplay.RoomState == ImageDisplay.State.StudyRoom)
        {
            currentDisplay.RoomState = ImageDisplay.State.ExperimentRoom;
            currentDisplay.CurrentWall = 5;
            Debug.Log("Door Hit");
        }
        else 
        {
            currentDisplay.RoomState = ImageDisplay.State.StudyRoom;
            currentDisplay.CurrentWall = 2;
        }
        

    }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
