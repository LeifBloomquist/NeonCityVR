using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestControl : MonoBehaviour
{
    public float speed = 1;
    public float turn = 1;

    private Rigidbody rb;
    private Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);  // Auto-Level
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();

        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float thrust = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        Vector3 NewForce  = new Vector3(0, stick.y * speed, thrust * speed);
        Vector3 NewTorque = new Vector3(0, stick.x * turn, 0);

        rb.AddRelativeForce(NewForce);
        rb.AddRelativeTorque(NewTorque);

        // Emergency Stop
        if (OVRInput.Get(OVRInput.Button.One))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Reset Position
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            transform.position = startpos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
