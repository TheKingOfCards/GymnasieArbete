using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    void Update()
    {
        Vector3 movement = new(0, 0, 0);

        transform.Translate(movement);
    }
}
