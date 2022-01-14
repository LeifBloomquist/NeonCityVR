using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCity : MonoBehaviour
{
    // Reference to the Prefabs. Drag a Prefab into this field in the Inspector.
    public GameObject[] BuildingPreFabs;

    private System.Random rnd = new System.Random(42);
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        //GridPlacement();
        //RandomPlacement();
        CorridorPlacement();
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }

    void RandomPlacement()
    {
        Vector3 terrainSize = GameObject.Find("Ground").GetComponent<Renderer>().bounds.size;

        for (int i = 0; i < 10000; i++)
        {
            float height = 100 + rnd.Next(200);

            int a = rnd.Next(BuildingPreFabs.Length);
            float px = Random.Range(0, terrainSize.x);
            float pz = Random.Range(0, terrainSize.z);
            float py = height / 2;

            GameObject newBuilding = BuildingPreFabs[a];
            float sy = newBuilding.transform.lossyScale.y; ;

            GameObject clone = Instantiate(newBuilding, new Vector3(px, sy / 2, pz), Quaternion.Euler(-90, 0, 0));
            //clone.transform.localScale = new Vector3(sx, sy, sz);
        }
    }

    void GridPlacement()
    {
        //Vector3 terrainSize = GameObject.Find("GridTerrain").GetComponent<Terrain>().terrainData.size;
        Vector3 terrainSize = GameObject.Find("Ground").GetComponent<Renderer>().bounds.size;

        int gridSize = 75;
        int cx = 0;        

        for (int x = 0; x < terrainSize.x; x += gridSize)
        {
            if ((++cx % 4) == 0) continue;

            int cz = 0;
            for (int z = 0; z < terrainSize.z; z += gridSize)
            {
                if ((++cz % 4) == 0) continue;

                //float height = 50 + rnd.Next(500);

                int a = rnd.Next(BuildingPreFabs.Length);
               

                //float sx = gridSize;
                //float sz = gridSize;
               // float sy = height;

                GameObject newBuilding = BuildingPreFabs[a];

                float y = newBuilding.transform.lossyScale.y;

                GameObject clone = Instantiate(newBuilding, new Vector3(x, y/2, z), Quaternion.Euler(-90,0,0));
                //clone.transform.localScale = new Vector3(sx, sy, sz);

                // Fix the texture scaling
                //Renderer rend = clone.GetComponent<Renderer>();
                //rend.material.mainTextureScale = new Vector2(5, height/20);
                //rend.material.mainTextureOffset = new Vector2(0, height/550);
            }
        }
    }

    void CorridorPlacement()
    {
        Vector3 terrainSize = GameObject.Find("Ground").GetComponent<Renderer>().bounds.size;

        float center_x = 5000f;
        int gridSpacing = 40;
        int cx = 0;

        for (int z = 0; z < terrainSize.z; z += gridSpacing)
        {
            if ((++cx % 4) == 0) continue;  // City blocks

            //float height = 50 + rnd.Next(500);

            float offset_x = 0f;

            // Left/right

            for (int lr=-400; lr <= 400; lr += gridSpacing)
            {
                if (Mathf.Abs(lr) < gridSpacing*2)  // Leave a gap in the middle
                {
                    continue;
                }

                int a = rnd.Next(BuildingPreFabs.Length);

                //float sx = gridSize;
                //float sz = gridSize;
                // float sy = height;

                offset_x = lr -20 + (float)rnd.Next(40);

                GameObject newBuilding = BuildingPreFabs[a];

                float x = center_x + offset_x;
                float y = newBuilding.transform.lossyScale.y;

                GameObject clone = Instantiate(newBuilding, new Vector3(x, y / 2, z), Quaternion.Euler(-90, 0, 0));
                //clone.transform.localScale = new Vector3(sx, sy, sz);

                // Fix the texture scaling
                //Renderer rend = clone.GetComponent<Renderer>();
                //rend.material.mainTextureScale = new Vector2(5, height/20);
                //rend.material.mainTextureOffset = new Vector2(0, height/550);

            }
        }
    }
}
