using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0;
    WaveConfigSO currentWave;
    public bool isLooping;
    [SerializeField] bool isBoss;

    LevelManager levelManager;

    private void Awake()
    {
        levelManager=FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        if (!isBoss)
            StartCoroutine("SpawnEnemyWaves");
        else
            StartCoroutine("SpawnBoss");
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetFirstWaypoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            
        }
        while (isLooping);

        yield return new WaitForSeconds(7);
        levelManager.LoadEndLevel();
    }

    IEnumerator SpawnBoss()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetFirstWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
        }
        yield return null;
    }




}
