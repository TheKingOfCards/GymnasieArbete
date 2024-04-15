using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [NonSerialized] public float gameTimer;
    [NonSerialized] public bool increaseGameTimer = true;
    [SerializeField] float moveSpeed = 10;
    Vector3 movement = new();
    Rigidbody rb;
    [SerializeField] AudioSource walkingSound;
    [NonSerialized] public int cluesAmount = 4;
    [NonSerialized] public bool canTakeInput = true;

    [Header("Text:")]
    [SerializeField] Text clueText;
    [SerializeField] Text playerThought;
    [SerializeField] float showTextTimer = 5;
    float showText;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        clueText.text = "Clues: 0/4";
    }


    void Update()
    {
        //Timer
        if (increaseGameTimer == true)
        {
            gameTimer += Time.deltaTime;
        }

        //Movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, 0, z);
        movement.Normalize();

        if (canTakeInput == true)
        {
            transform.Translate(moveSpeed * Time.deltaTime * movement);

            if (x == 0 && z == 0)
            {
                walkingSound.enabled = false;
            }
            else
            {
                walkingSound.enabled = true;
            }
        }

        //Player text
        if (cluesAmount == 4)
        {
            if (showText < showTextTimer)
            {
                playerThought.text = "I should head back to the gate by the car";
                showText += Time.deltaTime;
            }else
            {
                playerThought.text = "";
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clue")) //If player colides with a clue
        {
            cluesAmount++;
            clueText.text = $"Clues: {cluesAmount}/4";
            Destroy(other.gameObject);
        }
    }
}
