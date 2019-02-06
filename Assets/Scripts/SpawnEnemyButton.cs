using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyButton : MonoBehaviour {

    BuildManager buildManager;
    public GameObject button;
    public Spawner spawner;

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

        if (spawner.IsSpawning == false && spawner.IsLastWave() == false)
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
