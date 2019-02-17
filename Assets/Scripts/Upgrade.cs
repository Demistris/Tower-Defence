using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Vector3 positionOffset;
    public Spot targetSpot;
    BuildManager buildManager;

    public Text textCantUpgrade;

    public AudioSource upgradeSoundPrefab;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }
	
	void Update ()
    {
        if (GameManager.gameIsOver || GameManager.gameIsPaused)
        {
            this.enabled = false;
            return;
        }
    }

    public void onClick()
    {
        if (GameManager.gameIsOver || GameManager.gameIsPaused)
        {
            this.enabled = false;
            return;
        }

        if (PlayerStats.money < 250)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.money -= 250;

        PlayUpgradeSound();

        GameObject towerToBuild = BuildManager.instance.UpgradedTowerPrefab;
        GameObject spawnedUpgradedTower = (GameObject)Instantiate(towerToBuild, targetSpot.transform.position + positionOffset, targetSpot.transform.rotation);
        Destroy(gameObject);

        Destroy(targetSpot.SpawnedTower);

        targetSpot.SpawnedTower = spawnedUpgradedTower;
    }

    public void PlayUpgradeSound()
    {
        AudioSource upgradeSoundInstance = Instantiate(upgradeSoundPrefab);
        upgradeSoundInstance.Play();
    }
}
