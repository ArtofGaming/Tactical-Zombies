using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Transform>().position += new Vector3(-.25f, 0, 0);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        if (collision.collider.transform.tag == "Moving Box")
        {
            
            Rigidbody box = collision.collider.transform.GetComponent<Rigidbody>();

            if (box != null) 
            {
                box.velocity = new Vector3(-1, 0, 0) * 2f;
            }
        }
    }*/
}
