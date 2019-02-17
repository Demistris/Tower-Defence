using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public static bool gameIsPaused;
    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    public AudioSource gameOverMusic;
    public AudioSource WinningMusic;

    private void Start()
    {
        gameIsOver = false;
        gameIsPaused = false;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update ()
    {
        if (gameIsOver)
        {
            return;
        }

		if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameOverMusic.Play();
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        WinningMusic.Play();
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
