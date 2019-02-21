using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    public Vector3 positionOffset;
    public Spot targetSpot;
    BuildManager buildManager;

    public GameObject CantBuyText;
    private GameObject spawnedCantBuyText;

    public AudioSource buyingSoundPrefab;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
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

        if (PlayerStats.money < 200)
        {
            spawnedCantBuyText = Instantiate(CantBuyText, transform.position, targetSpot.transform.rotation, GameManager.Instance.canvas.transform);
            StartCoroutine(DeleteInfoText());
            return;
        }

        PlayerStats.money -= 200;

        PlayBuyingSound();

        GameObject towerToBuild = BuildManager.instance.StandardTowerPrefab;
        GameObject spawnedStandardTower = (GameObject)Instantiate(towerToBuild, targetSpot.transform.position + positionOffset, targetSpot.transform.rotation);
        Destroy(gameObject);

        targetSpot.SpawnedTower = spawnedStandardTower;
    }

    private IEnumerator DeleteInfoText()
    {
        yield return new WaitForSeconds(1f);
        Destroy(spawnedCantBuyText);
    }

    public void PlayBuyingSound()
    {
        AudioSource buyingSoundInstance = Instantiate(buyingSoundPrefab);
        buyingSoundInstance.Play();
    }
}