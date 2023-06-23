using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraRotation : MonoBehaviour
{
    [SerializeField] private Vector2 _rotationSpeed = new Vector2(0.1f, 0.1f);
    [SerializeField] private bool _reverse;
    [SerializeField] private float _smoothness = 5f;

    private Camera _camera;
    private Vector2 _lastMousePosition;
    private Vector2 _newAngle = Vector2.zero;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _newAngle = _camera.transform.localEulerAngles;
            _lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!_reverse)
            {
                _newAngle.y -= (_lastMousePosition.x - Input.mousePosition.x) * _rotationSpeed.y;
                _newAngle.x -= (Input.mousePosition.y - _lastMousePosition.y) * _rotationSpeed.x;
            }
            else
            {
                _newAngle.y -= (Input.mousePosition.x - _lastMousePosition.x) * _rotationSpeed.y;
                _newAngle.x -= (_lastMousePosition.y - Input.mousePosition.y) * _rotationSpeed.x;
            }

            _camera.transform.localEulerAngles = _newAngle;
            _lastMousePosition = Input.mousePosition;
        }
    }
}
