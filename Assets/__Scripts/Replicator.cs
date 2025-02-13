using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replicator : MonoBehaviour
{

    public GameObject outsidePrefab;
    private Vector3 newPos;
    public Vector3 offset = new Vector3(0, 0, 200);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            newPos = GetComponent<Transform>().position + offset;
            Instantiate(outsidePrefab, newPos, Quaternion.identity, GetComponent<Transform>().parent);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            return;
            //gameObject.SetActive(false);
        }
    }
}
