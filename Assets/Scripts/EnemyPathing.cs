﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
     WaveConfig waveConfig;
    [SerializeField] List<Transform> waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPositon = waypoints[waypointIndex].transform.position;
            var movementThisPosition = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPositon, movementThisPosition);
            if (transform.position == targetPositon)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
