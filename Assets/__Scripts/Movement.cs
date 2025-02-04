using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody rb; 
    public float force = 1;

    void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

    void Update()
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(new Vector3(0,0,1) * force * 2);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(new Vector3(0,0,-1) * force);
            }
        }
    

}

