using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level01";
    public SceneFader sceneFader;

    private const string IS_MUSIC_ON = "IsMusicOn";
    public AudioMixerGroup musicGroup;

    private void Start()
    {
        if (PlayerPrefs.GetInt(IS_MUSIC_ON) == 1)
        {
            musicGroup.audioMixer.SetFloat("musicVolume", 0f);
        }
        else
        {
            musicGroup.audioMixer.SetFloat("musicVolume", -80f);
        }
    }

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
