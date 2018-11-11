using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyButton : MonoBehaviour {

    BuildManager buildManager;
    public GameObject button;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("EnemyEasy").Length == 0)
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
        StartCoroutine(Spawner.Instance.SpawnWave());
    }
}
