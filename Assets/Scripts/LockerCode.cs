using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerCode : MonoBehaviour, IInteractable
{
    

    public void Interact(ImageDisplay currentDisplay)
    {
        if (transform.parent.GetComponent<CodeLock>()._isFourChar)
        {
            transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()]++;

            if (transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()] > 25)
                transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()] = 0;

            this.gameObject.GetComponent<SpriteRenderer>().sprite =
                transform.parent.GetComponent<CodeLock>()._symbolSprites[transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()]];
        }
        else
        {
            transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()]++;

            if (transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()] > 25)
                transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()] = 0;

            this.gameObject.GetComponent<SpriteRenderer>().sprite =
                transform.parent.GetComponent<CodeLock>()._symbolSprites[transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()]];

        }
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
