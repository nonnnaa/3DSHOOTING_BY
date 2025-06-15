using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("OnCollisionEnter  " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("OnTriggerEnter  " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
