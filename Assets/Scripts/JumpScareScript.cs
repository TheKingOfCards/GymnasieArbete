using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScareScript : MonoBehaviour
{
    float timeToAppearText;
    [SerializeField] GameObject jumpScare;
    [SerializeField] PlayerController pC;
    [SerializeField] GameObject player;
    [SerializeField] Camera mainCamera;
    [SerializeField] Text gameTimerText;

    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioSource forestSound;
    [SerializeField] AudioSource flashligtSound;


    bool textTimer = false;
    


    void Update()
    {
        if(textTimer == true)
        {
            timeToAppearText += Time.deltaTime;
        }

        if(timeToAppearText >= 3)
        {
            int rounded = Convert.ToInt32(pC.gameTimer);
            gameTimerText.text = $"{rounded}";
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PLAYER") && pC.cluesAmount == 4)
        {
            pC.canTakeInput = false;
            pC.increaseGameTimer = false;
            Vector3 playerNewPos = new(0, 1, 65);
            player.transform.position = playerNewPos;

            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            walkingSound.enabled = false;
            forestSound.enabled = false;
            flashligtSound.enabled = false;

            Instantiate(jumpScare, new Vector3(0, -1.6f, 67.2f), Quaternion.Euler(new Vector3(0, -180, 0)));

            textTimer = true;
        }
    }
}
