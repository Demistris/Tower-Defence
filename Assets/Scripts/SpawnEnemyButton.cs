using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyButton : MonoBehaviour {

    BuildManager buildManager;
    public GameObject button;
    public int numberOfClicks = 0;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        if (GameManager.gameIsPaused)
        {
            return;
        }

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void onClick()
    {
        if(GameManager.gameIsPaused)
        {
            return;
        }

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        Spawner.Instance.SpawnNextWave();
    }
}
