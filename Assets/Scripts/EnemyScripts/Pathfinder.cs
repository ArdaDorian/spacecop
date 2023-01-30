using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    [SerializeField] bool isBoss;

    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner= FindObjectOfType<EnemySpawner>();        
    }

    private void Start()
    {        
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.Waypoints();
        transform.position = waypoints[waypointIndex].position;        
    }

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPos= waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if (transform.position == targetPos )
            {
                waypointIndex++;
            }
        }
        else
        {
            if (!isBoss)
            {
                Destroy(gameObject);
            }
            else
            {
                waypointIndex = 0;
            }
            
        }
    }
}
