using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingController : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 13f);
    }
}
