using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : SingletonMonoBehaviour<EnemySpawner>
{
    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private EnemyMovement enemy;

    [SerializeField] private float spawnTime;
    [SerializeField] private float variance;

    [SerializeField] private bool shouldSpawn;

    [SerializeField] private Transform player;

    void Start()
    {
        shouldSpawn = true;
        StartCoroutine(SpawnEnemy());
    }

    public void TriggerSpawn(bool shouldSpawn)
    {
        this.shouldSpawn = shouldSpawn;

        if (this.shouldSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (shouldSpawn) // Loop to keep spawning enemies
        {
            yield return new WaitForSeconds(GetRandomSpawnTime());

            SpawnNewEnemy();
        }
    }

    public void SpawnNewEnemy()
    {
        var chosenPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        EnemyMovement newEnemy = Instantiate(enemy, new Vector3(chosenPoint.position.x, chosenPoint.position.y, chosenPoint.position.z), Quaternion.identity);
        newEnemy.SetTarget(player);
    }

    private float GetRandomSpawnTime()
    {
        // Calculate a random spawn time based on the interval and variance
        float minTime = Mathf.Max(spawnTime - variance, 0); // Ensure time doesn't go negative
        float maxTime = spawnTime + variance;
        return Random.Range(minTime, maxTime);
    }
}
