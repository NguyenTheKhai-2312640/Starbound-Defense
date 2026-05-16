using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    public float spawnDistance;

    public float timeSinceLastSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnDistance;
        spawnPosition += (Vector2)transform.position;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
