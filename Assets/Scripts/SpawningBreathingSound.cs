using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBreathingSound : MonoBehaviour
{
    [SerializeField] Transform breathingSpawnPoint;
    [SerializeField] GameObject breathingPrefab;

    [SerializeField] float canStartSound = 50;
    float startSoundTimer;
    [SerializeField] int randomMax = 10;


    void Update()
    {
        startSoundTimer += Time.deltaTime;

        if (startSoundTimer >= canStartSound)
        {
            int index = Random.Range(0, randomMax - 1);

            if (index == 0)
            {
                Instantiate(breathingPrefab, breathingSpawnPoint.position, Quaternion.identity);
            }
            startSoundTimer = 0;
        }
    }
}