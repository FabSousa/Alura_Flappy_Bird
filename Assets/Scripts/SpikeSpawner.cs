using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private float minSpawnDelay = 1.5f;
    [SerializeField] private float maxSpawnDelay = 3;
    private float count = 2;
    private float timeToDestroy = 3;
    private float minH = -1.8f;
    private float maxH = 1;

    private void Update()
    {
        count += Time.deltaTime;
        if(count >= Random.Range(minSpawnDelay, maxSpawnDelay)){
            SpawnSpike();
            count = 0;
        }
    }


    private void SpawnSpike(){
        Destroy(Instantiate(spikePrefab, transform.position + RandomizeHeight(), Quaternion.identity), timeToDestroy);
    }

    private Vector3 RandomizeHeight(){
        return Vector3.up * Random.Range(minH, maxH);
    }
}
