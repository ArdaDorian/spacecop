using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed;
    [SerializeField] float spawnerTime = 1f;
    [SerializeField] float spawnTimeVariance = 0;
    [SerializeField] float minSpawnTime = .2f;
    public Transform GetFirstWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> Waypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;   
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(spawnerTime-spawnTimeVariance, spawnerTime+spawnTimeVariance);
        return Mathf.Clamp(spawnerTime, minSpawnTime, float.MaxValue);
    }
}
