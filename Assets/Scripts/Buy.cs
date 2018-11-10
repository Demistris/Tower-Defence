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
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        standardTower = (GameObject)Instantiate(towerToBuild, targetSpot.transform.position + positionOffset, targetSpot.transform.rotation);
        Destroy(gameObject);
        //przypisuje prefab standartTower do public GameObject tower
        targetSpot.tower = standardTower;
    }
}
