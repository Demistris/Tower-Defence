using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Vector3 positionOffset;
    public Spot targetSpot;
    BuildManager buildManager;

    public GameObject CantUpgradeText;
    private GameObject spawnedCantUpgradeText;

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
            spawnedCantUpgradeText = Instantiate(CantUpgradeText, transform.position, targetSpot.transform.rotation, GameManager.Instance.canvas.transform);
            StartCoroutine(DeleteInfoText());
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

    private IEnumerator DeleteInfoText()
    {
        yield return new WaitForSeconds(1f);
        Destroy(spawnedCantUpgradeText);
    }

    public void PlayUpgradeSound()
    {
        AudioSource upgradeSoundInstance = Instantiate(upgradeSoundPrefab);
        upgradeSoundInstance.Play();
    }
}
