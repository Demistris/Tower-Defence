using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameIsOver;
    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update ()
    {
        if (gameIsOver)
            return;

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }

		if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
