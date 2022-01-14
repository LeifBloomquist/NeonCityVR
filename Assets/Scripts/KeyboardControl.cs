using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{
    public int speed = 100;
    public int turn = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);  // Auto-Level
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * speed / 2);
        }

        if  (Input.GetKey(KeyCode.W))
        {          
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -(speed/2));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.up * -turn);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * turn);
        }
    }
}
