using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector2 moveVal = new Vector2(0,0);
    Vector3 movement = new Vector3(0,0,0);
    [SerializeField]
    Quaternion rotation;
    Vector3 rotationSpeed = new Vector3(0,40,0);
   
    
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
        float turn = movement.x * Time.deltaTime * 50f;
        rotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * rotation);
        rb.MovePosition(rb.position + (transform.forward * movement.z + transform.right * movement.x) * Time.deltaTime * 5f);
        Physics.SyncTransforms();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
     //change so that forward is always forwards aka turn the character to face direction of movement
        moveVal = value.ReadValue<Vector2>();
        //input sometimes stops if using WASD and going from holding a horizontal and a up key to just holding a horizontal one
        movement = new Vector3(moveVal.x, 0, moveVal.y);
        
        

        /*if (value.canceled)
        {
            movement = new Vector3(0, 0, 0);
        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
    }
}
