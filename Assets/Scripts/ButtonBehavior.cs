using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public enum ButtonId 
    {
        moveButton, returnButton
    };

    public ButtonId ThisButtonId;

    private ImageDisplay _currentDisplay;


    // Update is called once per frame
    void Update()
    {
        HideButton();
        DisplayButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("ImageDisplay").GetComponent<ImageDisplay>();
    }

    private void HideButton()
    {
        if (_currentDisplay.CurrentState == ImageDisplay.State.StudyRoom && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;

        }
        else if (_currentDisplay.CurrentState == ImageDisplay.State.ExperimentRoom && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
        }


        if (_currentDisplay.CurrentState == ImageDisplay.State.ChangedView && ThisButtonId == ButtonId.moveButton) 
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
        }

        if (_currentDisplay.CurrentState == ImageDisplay.State.ChangedView_2 && ThisButtonId == ButtonId.moveButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
        }
    }

    private void DisplayButton()
    {
        if (_currentDisplay.CurrentState == ImageDisplay.State.StudyRoom && ThisButtonId == ButtonId.moveButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;

        }
        else if (_currentDisplay.CurrentState == ImageDisplay.State.ExperimentRoom && ThisButtonId == ButtonId.moveButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }


        if (_currentDisplay.CurrentState == ImageDisplay.State.ChangedView && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        if (_currentDisplay.CurrentState == ImageDisplay.State.ChangedView_2 && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
    }


}
