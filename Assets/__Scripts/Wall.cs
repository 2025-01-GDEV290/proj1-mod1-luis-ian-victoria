using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private int count;
    private float velocity;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.name == "Player")
        {
            rb = other.GetComponent<Rigidbody>();
            velocity = rb.velocity.magnitude;
            Debug.Log(velocity);

            if(velocity >= 10) {
                count++;
                if(count >= 3)
                {
                    gameObject.SetActive(false);
                }
            }

        }
    }
}
