using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public EnemyGroup easy;
        public EnemyGroup medium;
        public EnemyGroup hard;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public Transform enemy;
        public int count;
        public float interval;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int countWaves = 0;

    public Transform spawnPoint;
    public static Spawner Instance;
    public bool IsSpawning = false;

    public float timeBetweenWaves = 2f;
    private float countdown = 2f;

    public GameManager gameManager;

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
        CheckWinCondition();
    }

    public void SpawnNextWave()
    {
        StartCoroutine(SpawnWave(waves[nextWave]));
    }

    public IEnumerator SpawnWave(Wave wave)
    {
        countWaves++;

        IsSpawning = true;
        PlayerStats.rounds++;

        yield return SpawnEnemyGroup(wave.easy);
        yield return SpawnEnemyGroup(wave.medium);
        yield return SpawnEnemyGroup(wave.hard);

        IsSpawning = false;
        WaveComplited();
    }

    private IEnumerator SpawnEnemyGroup(EnemyGroup enemyGroup)
    {
        for (int i = 0; i < enemyGroup.count; i++)
        {
            SpawnEnemy(enemyGroup.enemy);
            yield return new WaitForSeconds(enemyGroup.interval);
        }
    }

    void WaveComplited()
    {
        countdown = timeBetweenWaves;

        nextWave++;
    }

    private void CheckWinCondition()
    {
        if (IsLastWave())
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.WinLevel();
                this.enabled = false;
            }
        }
    }

    public bool IsLastWave()
    {
        return nextWave >= waves.Length;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);
    }

}
