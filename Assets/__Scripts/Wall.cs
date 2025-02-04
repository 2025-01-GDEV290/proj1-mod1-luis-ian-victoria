using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private int count;
    private float velocity;
    public float radius = 100.0F;
    public float power = 10.0F;
    public Rigidbody rb;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;

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

                switch(count)
                {
                    case 1:
                        door1.SetActive(false);
                        door2.SetActive(true);
                        break;
                    case 2:
                        door2.SetActive(false);
                        door3.SetActive(true);
                        break;
                    case 3:
                        door3.SetActive(false);
                        door4.SetActive(true);
                        Vector3 explosionPos = transform.position - new Vector3(0,0,10);
                        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                        foreach (Collider hit in colliders)
                        {
                            Debug.Log(hit.gameObject.name);
                            Rigidbody rb = hit.GetComponent<Rigidbody>();

                            if (rb != null)
                                rb.AddExplosionForce(power, explosionPos, radius, 0);
                        }
                        gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
                //if(count >= 3)
                //{
                //   gameObject.SetActive(false);
                //}
            }

        }
    }
}
