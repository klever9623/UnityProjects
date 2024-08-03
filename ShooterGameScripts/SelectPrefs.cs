using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPrefs : MonoBehaviour
{
    private Transform _parent;
    private int _index;

    private void Start()
    {
        _parent = GetComponent<Transform>();

        for (int i = 0; i < _parent.childCount; i++)
        {
            if (_parent.GetChild(i).gameObject.activeInHierarchy)
            {
                _index = i;
                break;
            }
        }
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
            Select((int)Input.mouseScrollDelta.y);
    }

    private void Select(int amplitude)
    {
        _parent.GetChild(_index).gameObject.SetActive(false);

        if (amplitude < 0 && _index == 0)
            _index = _parent.childCount - 1;
        else if (amplitude > 0 && _index == _parent.childCount - 1)
            _index = 0;
        else
            _index += amplitude;

        _parent.GetChild(_index).gameObject.SetActive(true);
    }
}
