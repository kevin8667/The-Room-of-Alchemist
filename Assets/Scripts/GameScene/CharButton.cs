using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharButton : MonoBehaviour, IInteractable
{

    public enum ButtonType
    {
        Plus,Minus 
    };

    
    [SerializeField] GameObject _codeChar;
    [SerializeField] ButtonType _buttonType;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void Interact(ImageDisplay currentDisplay)
    {
        if (transform.parent.GetComponent<CodeLock>()._isFourChar)
        {
            if(_buttonType == ButtonType.Plus)
            {
                _codeChar.GetComponent<LockerCode>().AddNumber4();
                //transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()]++;
            }
            else
            {
                _codeChar.GetComponent<LockerCode>().SubNumber4();
                //transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()]--;
            }


            _codeChar.GetComponent<LockerCode>().Loop4();

            /**if (transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()] > 25)
            {
                transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()] = 0;
            }
            if (transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()] < 0)
            {
                transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()] = 25;
            }**/

            _codeChar.GetComponent<LockerCode>().ChangeSprite4(_codeChar);
            /**_codeChar.GetComponent<SpriteRenderer>().sprite =
                transform.parent.GetComponent<CodeLock>()._symbolSprites[transform.parent.GetComponent<CodeLock>()._currentIndividualIndex2[transform.GetSiblingIndex()]];**/
        }
        else
        {
            if (_buttonType == ButtonType.Plus)
            {
                _codeChar.GetComponent<LockerCode>().AddNumber3();
                //transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()]++;
            }
            else
            {
                _codeChar.GetComponent<LockerCode>().SubNumber3();
                //transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()]--;
            }

            _codeChar.GetComponent<LockerCode>().Loop3();
            /**if (transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()] > 25)
            {
                transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()] = 0;
            }
            if (transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()] < 0)
            {
                transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()] = 25;
            }**/

            _codeChar.GetComponent<LockerCode>().ChangeSprite3(_codeChar);
            /**_codeChar.GetComponent<SpriteRenderer>().sprite =
                transform.parent.GetComponent<CodeLock>()._symbolSprites[transform.parent.GetComponent<CodeLock>()._currentIndividualIndex[transform.GetSiblingIndex()]];**/

        }

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
