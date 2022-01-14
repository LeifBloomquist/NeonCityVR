using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    private Rigidbody rb;
    public float push = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        rb.AddForce(new Vector3(0, 0, push));   // A bit of a push forward
    }
}
