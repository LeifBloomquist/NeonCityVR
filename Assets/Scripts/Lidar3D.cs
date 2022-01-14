using System.Collections.Generic;
using UnityEngine;

public class Lidar3D : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }

    void FixedUpdate()
    {
        List<Vector3> AllHits = DoLidar();

        // Push the object away from the sum of all vectors

        Vector3 TotalPush = Vector3.zero;

        foreach (Vector3 push in AllHits)
        {
            float distance = Vector3.Distance(push, this.transform.position);
            Vector3 direction = push.normalized;

            float force = 0.1f / Mathf.Sqrt(distance);

            TotalPush -= (direction * force);  // Negative to push "away"
        }

        rb.AddForce(TotalPush * 10f);

        rb.AddForce(new Vector3(0, 0, 0.4f));   // A bit of a push forward
    }

    private List<Vector3> DoLidar()
    { 
        const float distance = 20f;
        const float spacing = 10f;
        Vector3 temp_hit = Vector3.zero;

        List<Vector3> AllHits = new List<Vector3>();

        for (float az_deg = 0; az_deg <= 360; az_deg += spacing)
        {
            for (float el_deg = 180; el_deg <= 360; el_deg += spacing)
            //float el_deg = 0;
            {
                float az_rad = az_deg * Mathf.Deg2Rad;
                float el_rad = el_deg * Mathf.Deg2Rad;
                Vector3 direction = ToCartesian(az_rad, el_rad, 1);
                bool hit = CastRay(direction, distance, out temp_hit);

                if (hit)
                {
                    AllHits.Add(temp_hit);
                }
            }
        }

        return AllHits;
    }

    private bool CastRay(Vector3 direction, float max_distance, out Vector3 hit_direction)
    {
        const float duration = 0.1f;

        bool hit = Physics.Raycast(this.transform.position, direction, out RaycastHit rayhit, max_distance);

        if (hit)
        {
            Vector3 hit_location = rayhit.point;
            Debug.DrawLine(this.transform.position, hit_location, Color.green, duration);
            hit_direction = hit_location - this.transform.position;
            return true;
        }
        else
        {
            hit_direction = Vector3.zero;
            return false;
        }
    }

    private Vector3 ToCartesian(float azimuth, float elevation, float radius)
    {
        float a = radius * Mathf.Cos(elevation);
        return new Vector3(a * Mathf.Cos(azimuth), radius * Mathf.Sin(elevation), a * Mathf.Sin(azimuth));
    }
}
