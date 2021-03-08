using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        var savedValue = PlayerPrefs.GetFloat("value");
        mixer.SetFloat("MasterVolume", savedValue);
    }

    void OnEnable()
    {
        mixer.GetFloat("MasterVolume", out float value);
        GetComponent<Slider>().value = value;
    }


    public void SetVolume(float value)
    {
        mixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("value", value);
        PlayerPrefs.Save();
    }

}
