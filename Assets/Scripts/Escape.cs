using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour,IInteractable
{
    [SerializeField] MagicCircle _magicCircle;
    [SerializeField] GameObject _text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact(ImageDisplay currentDisplay)
    {
        if (_magicCircle._isMagicEnabled)
        {
            _text.SetActive(true);
            _text.GetComponent<Text>().text = "YOU ESCAPED";
        }

    }
}
