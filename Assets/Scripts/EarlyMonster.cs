using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyMonster : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float moveTime = 2;
    float timer;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            rb.velocity = new Vector3(speed, 0, 0);
            Destroy(gameObject, 3);
        }
    }
}
