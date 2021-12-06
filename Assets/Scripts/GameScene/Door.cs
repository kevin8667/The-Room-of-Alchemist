using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip _doorSFX;

    public void Interact(ImageDisplay currentDisplay)
    {
        if (_doorSFX != null)
        {
            AudioHelper.PlayClip2D(_doorSFX, 1f);
        }
        if (currentDisplay.CurrentState == ImageDisplay.State.StudyRoom)
        {
            currentDisplay.CurrentState = ImageDisplay.State.ExperimentRoom;
            currentDisplay.CurrentWall = 5;
            Debug.Log("Door Hit");
        }
        else
        {
            currentDisplay.CurrentState = ImageDisplay.State.StudyRoom;
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
