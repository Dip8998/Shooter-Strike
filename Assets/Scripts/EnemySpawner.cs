using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemys;
    public bool canSpawn = true;
    public float spawnRate = 1.0f;
    float timer;
    [SerializeField] GameObject winScreen;
    void Update()
    {
        spawnRate -= 0.01f * UnityEngine.Time.deltaTime;
        if (canSpawn)
        {
            StartCoroutine(Spawner());
        }

    }

    IEnumerator  Spawner()
    {
        canSpawn = false;
        
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        for (int i = 0; i < enemys.Length; i++)
        {
            int rand = Random.Range(0, enemys.Length);
            GameObject enemyToSpawn = enemys[rand];
            Instantiate(enemyToSpawn, GetRandomSpawnPosition(), Quaternion.identity);
            yield return wait;
        }
        canSpawn = true;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Generate a random position around the player or in the scene
        float spawnRadius = 20f;  // Adjust as needed
        Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
        randomPos.y = 0;  // Keep on the same horizontal plane
        return randomPos + transform.position;  // Adjust spawn position relative to the spawner's position
    }
}