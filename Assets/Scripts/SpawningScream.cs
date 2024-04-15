using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScream : MonoBehaviour
{
    [SerializeField] float distance = 50;

    [SerializeField] float canSpawn = 30;
    float canSpawnTimer;
    [SerializeField] int randomNumberSpawn = 5;

    [SerializeField] GameObject scream;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DeepForest"))
        {
            canSpawnTimer += Time.deltaTime;
            if (canSpawnTimer > canSpawn)
            {
                int index = Random.Range(0, randomNumberSpawn - 1);
                
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
                
                canSpawnTimer = 0;
            }
        }
    }
}
