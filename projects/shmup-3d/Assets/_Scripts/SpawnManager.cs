using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;

    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private Transform player;

    [SerializeField] private float spawnTime;
    [SerializeField] private float variance;

    [SerializeField] private bool shouldSpawn;

    // Start is called before the first frame update
    void Start()
    {
        shouldSpawn = true;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (shouldSpawn) // Loop to keep spawning enemies
        {
            yield return new WaitForSeconds(GetRandomSpawnTime());

            var newEnemy = Instantiate(enemies[Random.Range(0,enemies.Count)], transform.position, transform.rotation);
            newEnemy.GetComponent<EnemyMovement>().SetDestination(targetPosition);
        }
    }

    private float GetRandomSpawnTime()
    {
        // Calculate a random spawn time based on the interval and variance
        float minTime = Mathf.Max(spawnTime - variance, 0); // Ensure time doesn't go negative
        float maxTime = spawnTime + variance;
        return Random.Range(minTime, maxTime);
    }
}
