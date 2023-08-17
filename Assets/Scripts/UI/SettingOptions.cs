using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingOptions : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("volumeMusic", volume);
    }
    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("volumeSFX", volume);
    }
}
