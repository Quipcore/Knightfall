using UnityEngine;
using UnityEngine.ProBuilder;

public class Door : MonoBehaviour
{
    
    Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    public void Open()
    {
        //transform.position = new Vector3(_originalPosition.x, _originalPosition.y - 50, _originalPosition.z);
        gameObject.SetActive(false);
    }

    public void Close()
    {
        transform.position = _originalPosition;
        gameObject.SetActive(true);
    }
}
