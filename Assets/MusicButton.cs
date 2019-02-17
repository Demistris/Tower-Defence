using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicButton : MonoBehaviour
{

    public AudioMixerGroup musicGroup;

	public void TurnOff()
    {
        musicGroup.audioMixer.SetFloat("musicVolume", -80f);
    }

    public void TurnOn()
    {
        musicGroup.audioMixer.SetFloat("musicVolume", 0f);
    }
}
