using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    private float musicVoluem = 1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        audioSource.volume = musicVoluem;
    }

    public void SetVoluem(float vol)
    {
        musicVoluem = vol;
    }
}
