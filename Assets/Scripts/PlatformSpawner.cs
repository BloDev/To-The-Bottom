﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float timer;
    public float spawnTimer;
    public float spawnSpeedIncrement;
    public float spawnSpeedMin;

    public float platformSpeed;
    public float platformSpeedIncrement;
    public float platformSpeedMax;
    
    private GameObject platform;

    // Start is called before the first frame update
    void Update()
    {
        if (timer <= 0f) {
            
            platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            int n = Random.Range(0, platform.transform.childCount - 1);

            Destroy(platform.transform.GetChild(n).gameObject);
            Destroy(platform.transform.GetChild(n + 1).gameObject);

            timer = spawnTimer;

            if (spawnTimer > spawnSpeedMin) {
                spawnTimer -= spawnSpeedIncrement;
            }

            if (platformSpeed < platformSpeedMax) {
                platformSpeed += platformSpeedIncrement;
            }
        }

        timer -= Time.deltaTime;
    }
}