using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControl : MonoBehaviour
{
    public Transform trans;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        // FPS : frame per second: 60 FPS 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        trans.Translate(new Vector3(x,0,z)* Time.deltaTime * speed); 
    }
}
