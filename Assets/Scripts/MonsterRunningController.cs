using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunningController : MonoBehaviour
{
    public int minSpeed = 15;
    public int maxSpeed = 20;
    int speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        Destroy(this.gameObject, 5f);
    }
}
