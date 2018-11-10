using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour {

    public GameObject standardTower;
    public Vector3 positionOffset;
    public Spot targetSpot;
    BuildManager buildManager;

	void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void onClick()
    {
        Debug.Log("Money: " + PlayerStats.money);

        if (PlayerStats.money < 200)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.money -= 200;

        Debug.Log("Tower build! Money left: " + PlayerStats.money);

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        standardTower = (GameObject)Instantiate(towerToBuild, targetSpot.transform.position + positionOffset, targetSpot.transform.rotation);
        Destroy(gameObject);

        //przypisuje prefab standartTower do public GameObject tower
        targetSpot.tower = standardTower;
    }
}
