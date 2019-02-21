using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static bool gameIsOver;
    public static bool gameIsPaused;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public GameObject canvas;

    public AudioSource gameOverMusic;
    public AudioSource WinningMusic;

    private void Start()
    {
        Instance = this;

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

        if(Input.GetKey("k"))
        {
            WinLevel();
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
        StartCoroutine(WaitForWin());
    }

    private IEnumerator WaitForWin()
    {
        yield return new WaitForSeconds(2);
        WinningMusic.Play();
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
