using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Camera[] _cameras;

    public Camera _current;

    private void Start()
    {
        _current = Camera.main;       
    }
    public void OnDropdownValueChanged(int index)
    {
        SetActiveCamera(_cameras[index]);
    }

    private void SetActiveCamera(Camera activeCamera)
    {
        foreach (Camera camera in _cameras)
        {
            camera.gameObject.SetActive(camera == activeCamera);
        }
    }
}
