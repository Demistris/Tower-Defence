using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffect : MonoBehaviour {

    public AudioSource buttonClick;

    public void PlayButtonClick()
    {
        buttonClick.Play();
    }
}
