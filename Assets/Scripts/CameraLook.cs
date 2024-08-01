using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    public float sensitivity = 3.5f;
    bool invertY = false;
    private CinemachineFreeLook freeLookComponent;

    // Start is called before the first frame update
    void Start()
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Look(InputAction.CallbackContext value)
    {
        Vector2 lookVal = value.ReadValue<Vector2>();
        lookVal.y = invertY ? -lookVal.y : lookVal.y;

        lookVal.x = lookVal.x * 180f;

        freeLookComponent.m_XAxis.Value += lookVal.x * Time.deltaTime;
        freeLookComponent.m_YAxis.Value += lookVal.y * sensitivity * Time.deltaTime;

    }
}
