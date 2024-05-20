using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectItems : MonoBehaviour
{
    private Transform _itemParent;

    [SerializeField] private TextMeshProUGUI _selectText;

    [SerializeField] private string _key;
    private int _currentIndex;
    private int _savedItemIndex;

    private void Start()
    {
        _itemParent = GetComponent<Transform>();

        for (int i = 0; i < _itemParent.childCount; i++)
            _itemParent.GetChild(i).gameObject.SetActive(false);

        _savedItemIndex = PlayerPrefs.HasKey(_key) ? PlayerPrefs.GetInt(_key) : 0;
        _currentIndex = _savedItemIndex;

        _itemParent.GetChild(_savedItemIndex).gameObject.SetActive(true);
        _selectText.text = _savedItemIndex == _currentIndex ? "Выбрано" : "Выбрать";
    }

    public void SelectLeft()
    {
        _itemParent.GetChild(_currentIndex).gameObject.SetActive(false);

        if (_currentIndex - 1 >= 0)
            _currentIndex--;
        else
            _currentIndex = _itemParent.childCount - 1;

        _itemParent.GetChild(_currentIndex).gameObject.SetActive(true);
        _selectText.text = _savedItemIndex == _currentIndex ? "Выбрано" : "Выбрать";
    }

    public void SelectRight()
    {
        _itemParent.GetChild(_currentIndex).gameObject.SetActive(false);

        if (_currentIndex + 1 < _itemParent.childCount)
            _currentIndex++;
        else
            _currentIndex = 0;

        _itemParent.GetChild(_currentIndex).gameObject.SetActive(true);
        _selectText.text = _savedItemIndex == _currentIndex ? "Выбрано" : "Выбрать";
    }

    public void SaveItem()
    {
        PlayerPrefs.SetInt(_key, _currentIndex);

        _savedItemIndex = _currentIndex;
        _selectText.text = "Выбрано";
    }
}
