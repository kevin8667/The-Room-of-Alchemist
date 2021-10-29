using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    [SerializeField] int[] _correctCombination;

    public Sprite[] _symbolSprites;

    public int[] _currentIndividualIndex = { 0, 0, 0 };
    public int[] _currentIndividualIndex2 = { 0, 0, 0, 0 };

    public bool _isOpened;

    

    public bool _isFourChar;

    // Start is called before the first frame update
    void Start()
    {
        _isOpened = false;

        LoadAllSymbolSprites();
    }

    // Update is called once per frame
    void Update()
    {

        OpenLocker();
        /**for (int i = 0; i < 3; i++)
        {
            Debug.Log(_correctCombination[i] == _currentIndividualIndex[i]);
            Debug.Log( transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1)[0]);

        }**/

    }

    void LoadAllSymbolSprites()
    {
        _symbolSprites = Resources.LoadAll<Sprite>("Sprites/CodeAlphabet");
    }

    bool VerifyCorrectCode()
    {
        bool correct = true;
        if (_isFourChar)
        {
            for (int i = 0; i < 4; i++)
            {
                if (_correctCombination[i] != _currentIndividualIndex2[i])
                {
                    correct = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                
                if (_correctCombination[i] != _currentIndividualIndex[i])
                {
                    correct = false;
                }
            }
        }
        

        return correct;
    }

    void OpenLocker()
    {
        if (_isOpened) return;

        if (VerifyCorrectCode())
        {
            _isOpened = true;

            if (_isFourChar)
            {
                for (int i = 0; i < 4; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    Debug.Log("Open");
                }
            }

        }
    }
}
