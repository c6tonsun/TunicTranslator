using UnityEngine;
using TMPro;

public class InputFieldController : MonoBehaviour
{
    TMP_InputField _wordField;
    public bool addSpace;

    void Start()
    {
        _wordField = GetComponent<TMP_InputField>();
    }

    public void AddToWord(TextMeshProUGUI text)
    {
        _wordField.text = string.Concat(_wordField.text, text.text);

        if (addSpace)
            _wordField.text = string.Concat(_wordField.text, " ");
    }

    public void Clear()
    {
        _wordField.text = "";
    }
}
