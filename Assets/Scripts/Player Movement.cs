using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector2 moveVal = new Vector2(0,0);
    Vector3 movement = new Vector3(0,0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void OnMove(InputAction.CallbackContext value)
    {
     //change so that forward is always forwards aka turn the character to face direction of movement
        Debug.Log("Moved");
        moveVal = value.ReadValue<Vector2>();
        movement = new Vector3(moveVal.x, 0, moveVal.y);
        rb.AddForce(movement * 10);
        




    }
}
