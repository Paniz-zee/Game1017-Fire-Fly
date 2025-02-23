using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] List<GameObject> activeObstacles;
    [SerializeField] int maxObstacles;

    private void Start()
    {
        activeObstacles = new List<GameObject>();
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }



    void SpawnObstacle()
    {
        if (activeObstacles.Count >= maxObstacles / 2)
            return;

        GameObject obstacleInst = Instantiate(obstaclePrefab, new Vector3(8.5f, Random.Range(-8.5f, 5.5f), 0f),
            Quaternion.identity, transform);
        activeObstacles.Add(obstacleInst);
    }


}

