using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private ImageDisplay currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("ImageDisplay").GetComponent<ImageDisplay>();
    }

    public void OnRightButtonClicked() 
    {
        currentDisplay.CurrentWall -= 1;
    }

    public void OnLeftButtonClicked()
    {
        currentDisplay.CurrentWall += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
