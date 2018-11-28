using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public GameObject upgradedTower;
    public Vector3 positionOffset;
    public Spot targetSpot;
    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }
	
	void Update ()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
    }

    public void onClick()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (PlayerStats.money < 150)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.money -= 150;

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        upgradedTower = (GameObject)Instantiate(towerToBuild, targetSpot.transform.position + positionOffset, targetSpot.transform.rotation);
        Destroy(gameObject);

        //przypisuje prefab upgradedTower do public GameObject tower
        targetSpot.tower = upgradedTower;
    }
}
