using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip CluePickUp;
    
    List<AudioClip> audioClips = new();

    void Start()
    {
        audioClips.Add(CluePickUp);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Clue"))
        {
            source.PlayOneShot(audioClips[0]);
        }
    }
}
