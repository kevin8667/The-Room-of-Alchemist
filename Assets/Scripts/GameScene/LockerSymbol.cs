using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerSymbol : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip _buttonSFX;

    [SerializeField] int _symbolNumber;

    public void Interact(ImageDisplay currentDisplay)
    {
        if (_buttonSFX != null)
        {
            AudioHelper.PlayClip2D(_buttonSFX, 1f);
        }

        transform.parent.GetComponent<SymbolLock>()._currentIndividualIndex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<SymbolLock>()._currentIndividualIndex[transform.GetSiblingIndex()] > _symbolNumber - 1)
            transform.parent.GetComponent<SymbolLock>()._currentIndividualIndex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<SymbolLock>()._symbolSprites[transform.parent.GetComponent<SymbolLock>()._currentIndividualIndex[transform.GetSiblingIndex()]];
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
