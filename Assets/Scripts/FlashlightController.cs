using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickClip;
    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            audioSource.PlayOneShot(clickClip);
        }
    }
}
