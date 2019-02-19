using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    private const string IS_MUSIC_ON = "IsMusicOn";
    public AudioMixerGroup musicGroup;
    public Toggle toggle;
    private bool isStartOver;

    private void Start()
    {
        if (PlayerPrefs.GetInt(IS_MUSIC_ON) == 1)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        isStartOver = true;
    }

    public void TurnOff()
    {
        musicGroup.audioMixer.SetFloat("musicVolume", -80f);
        toggle.isOn = false;
    }

    public void TurnOn()
    {
        musicGroup.audioMixer.SetFloat("musicVolume", 0f);
        toggle.isOn = true;
    }

    public void IsMusicOn()
    {
        if (isStartOver == false)
        {
            return;
        }

        if (PlayerPrefs.GetInt(IS_MUSIC_ON) == 1)
        {
            TurnOff();
            PlayerPrefs.SetInt(IS_MUSIC_ON, 0);
        }
        else
        {
            TurnOn();
            PlayerPrefs.SetInt(IS_MUSIC_ON, 1);
        }
    }
}