using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] List<GameObject> activeEnemies;
    [SerializeField] int maxEnemies;

    private void Start()
    {
        activeEnemies = new List<GameObject>();
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearAllEnemies();
        }
    }

    void SpawnEnemy()
    {
        if (activeEnemies.Count >= maxEnemies / 2)
            return;

        GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(8.5f, Random.Range(-8.5f, 5.5f), 0f),
            Quaternion.identity, transform);

       
        //float randShade = Random.Range(0.75f, 1.0f);
        //enemyInst.GetComponentInChildren<SpriteRenderer>().color = new Color(randShade, randShade, randShade);  
        activeEnemies.Add(enemyInst);
    }

    void ClearAllEnemies()
    {
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            Destroy(activeEnemies[i]);
        }
        activeEnemies.Clear();
    } }


    //[SerializeField] GameObject enemyPrefab;
    //[SerializeField] float spawnInterval;
    //[SerializeField] List<GameObject> activeEnemies;
    //public int maxEnemies;

//private void Start()
//{
//    activeEnemies = new List<GameObject>();
//    InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
//}
//void Update()
//{
//    //if (Input.GetKeyDown(KeyCode.E))
//    //{
//    SpawnEnemy();
//    //}
//    if (Input.GetKeyDown(KeyCode.C))
//    {
//        for (int i = 0; i < activeEnemies.Count; i++)
//        {
//            Destroy(activeEnemies[i]);
//        }
//        activeEnemies.Clear();
//    }
//}
//void SpawnEnemy()
//{

//    GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(8.5f, Random.Range(-8.5f, 5.5f), 0f),
//        Quaternion.identity, transform);

//    float randShade = Random.Range(0.75f, 1.0f);
//    enemyInst.GetComponentInChildren<SpriteRenderer>().color = new Color(randShade, randShade, randShade);

//    activeEnemies.Add(enemyInst);

//}
//}
