using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private Vector2 easySpawnDelayRange;
    [SerializeField] private Vector2 hardSpawnDelayRange;
    [SerializeField] private float timeToMaxDifficulty;
    [SerializeField] private float minH = -1.5f;
    [SerializeField] private float maxH = 1;
    private float passedTime;
    private float minSpawnDelay;
    private float maxSpawnDelay;
    private float difficulty;
    private float count = 2;
    private float timeToDestroy = 12;

    private void Update()
    {
        UpdateDifficulty();
        UpdateSpawnTime();
        countDown();
    }

    private void UpdateDifficulty(){
        passedTime += Time.deltaTime;
        difficulty = passedTime / timeToMaxDifficulty;
        difficulty = Mathf.Min(1, difficulty);
    }

    private void UpdateSpawnTime(){
        minSpawnDelay = Mathf.Lerp(easySpawnDelayRange.x, hardSpawnDelayRange.x, difficulty);
        maxSpawnDelay = Mathf.Lerp(easySpawnDelayRange.y, hardSpawnDelayRange.y, difficulty);
    }

    private void countDown(){
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
