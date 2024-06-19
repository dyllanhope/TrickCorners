using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to be spawned
    public Transform diamondCenter;  // Center of the diamonds
    public float outerDiamondSize;   // The size of the outer diamond (side length)
    public float innerDiamondSize;   // The size of the inner diamond (side length)

    void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        Vector2 randomPoint = GetRandomPointInOuterDiamond();
        Instantiate(objectToSpawn, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
    }

    Vector2 GetRandomPointInOuterDiamond()
    {
        float outerHalfSize = outerDiamondSize / 2f;
        float innerHalfSize = innerDiamondSize / 2f;
        Vector2 randomPoint;

        do
        {
            // Generate a random point within the bounding box of the outer diamond
            float randomX = Random.Range(-outerHalfSize, outerHalfSize);
            float randomY = Random.Range(-outerHalfSize, outerHalfSize);
            randomPoint = new Vector2(randomX, randomY);
        }
        // Check if the point lies within the outer diamond and outside the inner diamond
        while (Mathf.Abs(randomPoint.x) + Mathf.Abs(randomPoint.y) > outerHalfSize || Mathf.Abs(randomPoint.x) + Mathf.Abs(randomPoint.y) < innerHalfSize);

        // Transform the point to the diamond's center position
        randomPoint += (Vector2)diamondCenter.position;

        return randomPoint;
    }
}
