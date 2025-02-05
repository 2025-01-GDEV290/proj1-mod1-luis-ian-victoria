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
    public GameObject engine_slowdown_slow_obj;
    public GameObject hit_sound_obj_1;
    public GameObject hit_sound_obj_2;
    public GameObject hit_sound_obj_3;
    public GameObject hit_sound_obj_4;

    private AudioSource engine_rev;
    private AudioSource engine_idle;
    private AudioSource engine_slowdown;
    private AudioSource engine_slowdown_slow;
    private AudioSource hit_1;
    private AudioSource hit_2;
    private AudioSource hit_3;
    private AudioSource hit_4;


    void Start()
        {
            rb = GetComponent<Rigidbody>();
            engine_rev = engine_rev_obj.GetComponent<AudioSource>();
            engine_idle = GetComponent<AudioSource>();
            engine_slowdown = engine_slowdown_obj.GetComponent<AudioSource>();
            engine_slowdown_slow = engine_slowdown_slow_obj.GetComponent<AudioSource>();
            hit_1 = hit_sound_obj_1.GetComponent<AudioSource> ();
            hit_2 = hit_sound_obj_2.GetComponent<AudioSource> ();
            hit_3 = hit_sound_obj_3.GetComponent<AudioSource> () ;
            hit_4 = hit_sound_obj_4.GetComponent<AudioSource> ();
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
                if (rb.velocity.magnitude > 20) {
                    engine_slowdown.Play();
                } else if(rb.velocity.magnitude > 4) {
                    engine_slowdown_slow.Play();
                }
                
            }
        }
    
    void OnCollisionEnter(Collision other)
        {
            switch(Random.Range(0,3)){
                    case 0:
                        hit_1.Play();
                        break;
                    case 1:
                        hit_2.Play();
                        break;
                    case 2:
                        hit_3.Play();
                        break;
                    case 3:
                        hit_4.Play();
                        break;
                    default:
                        break;
                }
            if (other.gameObject.tag != "Door"){
                engine_rev.Stop();
                Debug.Log("Collided with not door");
                
            }
                
        }
}
    



