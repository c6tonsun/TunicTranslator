using UnityEngine;

public class CryptSolution : MonoBehaviour
{
    public Transform phoneme1, phoneme2;
    Transform _cryptVowel, _cryptConsonant;
    string _vowelStr, _consonantStr;
    PointerMover _pointerMover;

    void Start()
    {
        _pointerMover = FindObjectOfType<PointerMover>();
    }

    public void SetCrypt(Transform crypt, bool isVowel)
    {
        if (isVowel)
        {
            if (_cryptVowel)
                DestroyImmediate(_cryptVowel.gameObject);

            _cryptVowel = Instantiate(crypt, transform);
            _cryptVowel.transform.position = transform.position;
            _vowelStr = crypt.name;
        }
        else
        {
            if (_cryptConsonant)
                DestroyImmediate(_cryptConsonant.gameObject);

            _cryptConsonant = Instantiate(crypt, transform);
            _cryptConsonant.transform.position = transform.position;
            _consonantStr = crypt.name;
        }
    }

    public void Clear()
    {
        if (_cryptVowel)
            DestroyImmediate(_cryptVowel.gameObject);

        if (_cryptConsonant)
            DestroyImmediate(_cryptConsonant.gameObject);

        _vowelStr = "";
        _consonantStr = "";
        SetPhonemes();
    }

    public void SetPhonemes()
    {
        phoneme1.GetChild(_pointerMover.GetCounter()).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = string.Concat(_consonantStr, _vowelStr);
        phoneme2.GetChild(_pointerMover.GetCounter()).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = string.Concat(_vowelStr, _consonantStr);
    }

    public void ClearPhonemes()
    {
        for (int i = 0; i < phoneme1.childCount; i++)
        {
            phoneme1.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "";
            phoneme2.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }
}
