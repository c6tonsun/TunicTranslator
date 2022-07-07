using UnityEngine;
using UnityEngine.UI;

public class PointerMover : MonoBehaviour
{
    const int SELECTED = 0, SELECTABLE = 1;
    const string POINTER = "v", CLEAR = " ";

    Color _selectable, _selected;

    public int _index;
    public int Index
    {
        get 
        {
            return _index;
        }
        set 
        {
            if (value < transform.childCount)
                _index = value;
            else
                _index = 0;

            UpdatePointer();
        }
    }

    void Start()
    {
        _selected = transform.GetChild(SELECTED).GetComponent<Image>().color;
        _selectable = transform.GetChild(SELECTABLE).GetComponent<Image>().color;
    }

    void UpdatePointer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == _index)
            {
                transform.GetChild(i).GetComponent<Image>().color = _selected;
                transform.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = POINTER;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color = _selectable;
                transform.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = CLEAR;
            }
        }
    }
}
