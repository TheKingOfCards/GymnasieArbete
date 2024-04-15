using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoopyThingsController : MonoBehaviour
{
    bool somethingHappening = false;


    [Header("Running Sound:")]
    [SerializeField] Transform leftSpawnPoint;
    [SerializeField] Transform rightSpawnPoint;
    [SerializeField] GameObject runningByPrefab;

    [SerializeField] float runningCanSpawn = 10f;
    float runningTimer;
    [SerializeField] int runningRandomMax = 4;


    [Header("Breathing Sound:")]
    [SerializeField] Transform breathingSpawnPoint;
    [SerializeField] GameObject breathingPrefab;
    [SerializeField] float breathingCanSpawn = 50;
    float breathingTimer;
    [SerializeField] int breathingRandomMax = 10;


    [Header("Scream Sound:")]
    [SerializeField] float distance = 50;
    [SerializeField] float screamCanSpawn = 30;
    float screamTimer;
    [SerializeField] int screamRandomMax = 5;
    [SerializeField] GameObject scream;


    void Update()
    {

    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("IsInForest"))
        {
            if(somethingHappening == false) SpawnRunningSound();
            
            if(somethingHappening == false) SpawnBreathingSound(); 
        }

        if(other.CompareTag("DeepForest"))
        {
            if(somethingHappening == false) SpawnScreamSound();
        }
        
    }


    void SpawnRunningSound()
    {
        runningTimer += Time.deltaTime;

        if (runningTimer >= runningCanSpawn) //Makes a random number that decides if it can spawn
        {
            int index = Random.Range(0, runningRandomMax);

            if (index == 0)
            {
                int randomSideSpawn = Random.Range(0, 2);

                if (randomSideSpawn == 0) //Spawns on left side
                {
                    Instantiate(runningByPrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
                }
                else //Spawn on right side
                {
                    Instantiate(runningByPrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
                }
            }
            runningTimer = 0;
        }
    }


    void SpawnBreathingSound()
    {
        breathingTimer += Time.deltaTime;

        if (breathingTimer >= breathingCanSpawn)
        {
            int index = Random.Range(0, breathingRandomMax);

            if (index == 0)
            {
                Instantiate(breathingPrefab, breathingSpawnPoint.position, Quaternion.identity);
            }
            breathingTimer = 0;
        }
    }


    void SpawnScreamSound()
    {
        screamTimer += Time.deltaTime;

        if (screamTimer > screamCanSpawn)
        {
            int index = Random.Range(0, screamRandomMax);

            if (index == 0)
            {
                Vector3 spawnPoint = new Vector3(
                    Random.Range(-1f, 1f),
                    0,
                    Random.Range(-1f, 1f)
                );

                spawnPoint.Normalize();
                spawnPoint *= distance;
                Instantiate(scream, transform.position + spawnPoint, Quaternion.identity);
            }
            screamTimer = 0;
        }
    }
}
