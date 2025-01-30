using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb; 

    void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

    void Update()
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(new Vector3(0,0,1));
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(new Vector3(0,0,-1));
            }
        }
    

}

