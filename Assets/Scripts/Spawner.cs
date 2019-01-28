using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform enemyEasyPrefab;
    public Transform enemyMediumPrefab;
    public Transform enemyHardPrefab;

    public Transform spawnPoint;
    public static Spawner Instance;

    public bool IsSpawning = false;

    public float timeBetweenWaves = 2f;
    private float countdown = 2f;

    private int waveIndex = 15;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
    }

    public IEnumerator SpawnWave()
    {
        IsSpawning = true;
        PlayerStats.rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemyEasy();
            yield return new WaitForSeconds(0.5f);
        }

         IsSpawning = false;
    }

    void SpawnEnemyEasy()
    {
        Instantiate(enemyEasyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnEnemyMedium()
    {
        Instantiate(enemyMediumPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnEnemyHard()
    {
        Instantiate(enemyHardPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
