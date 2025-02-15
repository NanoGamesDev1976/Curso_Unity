﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    //private float startDelay = 1.0f;
    //private float spawnInterval = 4.0f;
    private int _indexBall;
    
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        _indexBall = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[_indexBall], spawnPos, ballPrefabs[_indexBall].transform.rotation);
    }

    private float counter=0f;
    private float nextWaitTime = 5f;
    
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter>= nextWaitTime)
        {
            counter = 0;
            Debug.LogFormat("Se esperaron {0} segundos para generar esta bola",nextWaitTime);
            nextWaitTime = Random.Range(1f, 5f);
            Invoke("SpawnRandomBall",0);
        }
        
    }
}
