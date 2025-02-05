using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody rb; 
    public float force = 1;
    public GameObject engine_rev_obj;
    public GameObject engine_slowdown_obj;

    public AudioSource engine_rev;
    public AudioSource engine_idle;
    public AudioSource engine_slowdown;

    void Start()
        {
            rb = GetComponent<Rigidbody>();
            engine_rev = engine_rev_obj.GetComponent<AudioSource>();
            engine_idle = GetComponent<AudioSource>();
            engine_slowdown = engine_slowdown_obj.GetComponent<AudioSource>();
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
            if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
            {
                engine_rev.Play();
            }
            if ((Input.GetKeyUp("w") || Input.GetKeyUp("s")) && rb.velocity.magnitude > 1)
            {
                engine_rev.Stop();
                engine_slowdown.Play();
            }
        }
    
    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag != "Door"){
                engine_rev.Stop();
                Debug.Log("Collided with not door");
            }
        }
    

}

