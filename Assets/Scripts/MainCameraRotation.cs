using UnityEngine;

public class MainCameraRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceToTarget = 10;

    private Vector3 _previousPosition;

    private void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            _previousPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = _previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180;
            float rotationAroundXAxis = direction.y * 180;

            _camera.transform.position = _target.position;

            _camera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            _camera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            _camera.transform.Translate(new Vector3(0, 0, -_distanceToTarget));

            _previousPosition = newPosition;
        }
    }
}