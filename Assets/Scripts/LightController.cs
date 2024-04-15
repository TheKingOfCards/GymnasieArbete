using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light mylight;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickClip;

    float timeBetweenClicks;
    [SerializeField] float canClick;
    [SerializeField] float intensity = 5;

    [SerializeField] PlayerController pC;


    void Start()
    {
        mylight = GetComponent<Light>();
    }


    void Update()
    {
        timeBetweenClicks += Time.deltaTime;
        if(Input.GetAxisRaw("Fire1") == 1 && timeBetweenClicks > canClick && pC.canTakeInput == true)
        {
            if(mylight.intensity == intensity)
            {
                mylight.intensity = 0;
            }else
            {
                mylight.intensity = intensity;
            }

            audioSource.PlayOneShot(clickClip);

            timeBetweenClicks = 0;
        }
    }
}
