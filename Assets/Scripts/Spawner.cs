using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public static Spawner Instance;

    public bool IsSpawning = false;

    public float timeBetweenWaves = 2f;
    private float countdown = 2f;

    private int waveIndex = 10;

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
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex += 5;

        IsSpawning = false;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
