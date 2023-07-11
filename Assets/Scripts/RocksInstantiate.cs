using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] rocks;
    [SerializeField] private Transform[] spawnPoints;
    private void Start()
    {
        StartCoroutine(SpawnRocks());
    }

    private IEnumerator SpawnRocks()
    {
        yield return new WaitForSeconds(2f);
        Spawning();
        StartCoroutine(SpawnRocks());
    }

    private void Spawning()
    {
        int randomRock = Random.Range(0, rocks.Length);
        int randomSpawn = Random.Range(0, spawnPoints.Length);
        Instantiate(rocks[randomRock], spawnPoints[randomSpawn].position, Quaternion.identity);
    }
}
