using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private const string IS_SOUND_ON = "IsSoundOn";
    public AudioMixerGroup soundGroup;
    public Toggle toggle;
    private bool isStartOver;

    private void Start()
    {
        if (PlayerPrefs.GetInt(IS_SOUND_ON) == 1)
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
        soundGroup.audioMixer.SetFloat("soundVolume", -80f);
        toggle.isOn = false;
    }

    public void TurnOn()
    {
        soundGroup.audioMixer.SetFloat("soundVolume", 0f);
        toggle.isOn = true;
    }

    public void IsSoundOn()
    {
        if (isStartOver == false)
        {
            return;
        }

        if (PlayerPrefs.GetInt(IS_SOUND_ON) == 1)
        {
            TurnOff();
            PlayerPrefs.SetInt(IS_SOUND_ON, 0);
        }
        else
        {
            TurnOn();
            PlayerPrefs.SetInt(IS_SOUND_ON, 1);
        }
    }
}