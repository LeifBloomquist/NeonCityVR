using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    //adjust this to change speed
    public float speed = 1f;
    //adjust this to change how high it goes
    public float height = 1f;

    public float phase = 0.5f;

    private float initialY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        initialY = pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = initialY + ( height * Mathf.Sin((Time.time + phase) * speed) );
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
