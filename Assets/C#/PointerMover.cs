using UnityEngine;

public class PointerMover : MonoBehaviour
{
    public Transform phoneme;
    Vector3 _newPos;
    public float _originalX, _offsetX;
    int  _counter = 0;

    void Start()
    {
        _originalX = phoneme.GetChild(0).position.x;
        _offsetX = Mathf.Abs(_originalX - phoneme.GetChild(1).position.x);

        _newPos = transform.position;
        _newPos.x = _originalX;
        transform.position = _newPos;
    }

    public void MovePointer()
    {
        _counter++;

        if (_counter < phoneme.childCount)
        {
            _newPos.x += _offsetX;
            transform.position = _newPos;
        }
        else
        {
            _counter = 0;
            _newPos.x = _originalX;
            transform.position = _newPos;
        }

    }

    public void ResetPointer()
    {
        _counter = phoneme.childCount;
        MovePointer();
    }

    public int GetCounter()
    {
        return _counter;
    }
}
