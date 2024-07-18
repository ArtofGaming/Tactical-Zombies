using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Look(InputAction.CallbackContext value)
    {
        Debug.Log("Looked");
        Vector3 lookVal = value.ReadValue<Vector2>();
        float lookX = Mathf.Repeat(lookVal.x, 360);
        float lookY = lookVal.y * sensitivity * Time.deltaTime;
        Camera.main.transform.rotation = Quaternion.Euler(lookY,lookX, 0f);

    }
}
