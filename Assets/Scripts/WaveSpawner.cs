using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private enum SpawnState { Spawning, Waiting, Counting};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float rate;
    }

    [SerializeField]
    private Wave[] waves;
    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float timeBetweenWaves = 5f;
    [SerializeField]
    private float waveCountdown;

    private SpawnState state = SpawnState.Counting;

    private int nextWave = 0;
    private float enemySearchCountdown = 1;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!WaveEnemyAliveCheck())
            {
                OnWaveComplete();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private bool WaveEnemyAliveCheck()
    {
        enemySearchCountdown -= Time.deltaTime;

        if (enemySearchCountdown <= 0)
        {
            enemySearchCountdown = 1f;
            if (transform.childCount == 0)
            {
                return false;
            }            
        }
        return true;
    }

    private void OnWaveComplete()
    {
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            this.enabled = false;
        }

        nextWave++;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation, this.gameObject.transform);
    }
}
