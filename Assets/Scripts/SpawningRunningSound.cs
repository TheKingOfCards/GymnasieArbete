using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawningRunningSound : MonoBehaviour
{
    [SerializeField] Transform leftSpawnPoint;
    [SerializeField] Transform rightSpawnPoint;
    [SerializeField] GameObject runningByPrefab;

    [SerializeField] float canTryForSpawn = 10f;
    [SerializeField] int randomSpawnMax = 4;
    float tryForSpawnTime;



    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("IsInForest"))
        {
            tryForSpawnTime += Time.deltaTime;

            if (tryForSpawnTime >= canTryForSpawn) //Makes a random number that decides if it can spawn
            {
                int tryRandomForSpawn = Random.Range(0, randomSpawnMax - 1);


                if (tryRandomForSpawn == 0)
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
                    tryForSpawnTime = 0;
                }
            }
        }
    }
}
