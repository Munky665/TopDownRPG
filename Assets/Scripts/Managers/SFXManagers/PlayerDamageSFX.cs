﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSFX : MonoBehaviour
{

    public static PlayerDamageSFX instance;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        if (source.clip != sound)
        {
            source.clip = sound;
            source.Play();
        }
    }

}
