using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSFX : MonoBehaviour
{
    public static EnemyDamageSFX instance;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.clip = sound;
        source.Play();
    }
}
