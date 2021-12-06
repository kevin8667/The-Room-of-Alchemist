using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolLock : MonoBehaviour
{
    [SerializeField] string _correctCombination;

    public GameObject _lockerSprite;

    [SerializeField] string _unlockedSpriteName;

    public Sprite[] _symbolSprites;

    public int[] _currentIndividualIndex = { 0, 0, 0 };

    private bool _isOpened;

    [SerializeField] private GameObject _objectInsideLocker;

    [SerializeField] private GameObject _linkViewPoint;

    [SerializeField] AudioClip _solvingSFX;

    [SerializeField] string _spriteName;

    [SerializeField] int _numbers;



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
    }

   void LoadAllSymbolSprites()
    {
        _symbolSprites = Resources.LoadAll<Sprite>("Sprites/" + _spriteName);
    }

    bool VerifyCorrectCode()
    {
        bool correct = true;

        for (int i = 0; i < _numbers-1; i++)
        {
            if (_correctCombination[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1)[0])
            {
                correct = false;
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

            if (_solvingSFX != null)
            {
                AudioHelper.PlayClip2D(_solvingSFX, 1f);
            }

            _lockerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + _unlockedSpriteName);

            for (int i = 0; i < _numbers - 1; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            _objectInsideLocker.SetActive(true);
            _linkViewPoint.GetComponent<ChangeView>()._isLockerUnlocked = true;
        }
    }
}
