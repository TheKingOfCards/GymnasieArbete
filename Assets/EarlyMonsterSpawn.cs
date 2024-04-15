using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyMonsterSpawn : MonoBehaviour
{
    [SerializeField] GameObject earlyMonster;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PLAYER"))
        {
            Instantiate(earlyMonster, new Vector3(-52f, 0.5f, 54), Quaternion.Euler(0, -90, 0));
        }
    }
}
