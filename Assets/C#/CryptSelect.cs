using UnityEngine;

public class CryptSelect : MonoBehaviour
{
    public bool Vowels;

    Camera _cam;
    Transform _child;
    CryptSolution _cryptSolution;
    Vector3 _mouseWorldPos, _mouseScreenPos, _selectArea = new Vector3(0.4784141f, 0.7096832f, 0f);

    void Start()
    {
        _cam = FindObjectOfType<Camera>();
        _cryptSolution = FindObjectOfType<CryptSolution>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseScreenPos = Input.mousePosition;
            _mouseScreenPos.z = _cam.transform.position.z;
            _mouseWorldPos = _cam.ScreenToWorldPoint(_mouseScreenPos);

            for (int i = 0; i < transform.childCount; i++)
            {
                _child = transform.GetChild(i);

                if (Mathf.Abs(_mouseWorldPos.x - _child.position.x) < _selectArea.x && Mathf.Abs(_mouseWorldPos.y - _child.position.y) < _selectArea.y)
                {
                    _cryptSolution.SetCrypt(_child, Vowels);
                    break;
                }
            }
        }
    }
}
