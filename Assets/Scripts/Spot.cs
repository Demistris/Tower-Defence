using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public Vector3 buttonPosition;

    public GameObject buyButton;
    public GameObject canvas;
    public GameObject SpawnedTower;
    private GameObject spawnedBuyButton;
    public GameObject upgradeButton;
    private GameObject spawnedUpgradeButton;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (GameManager.gameIsOver || GameManager.gameIsPaused)
        {
            this.enabled = false;
            return;
        }

        buyButton.GetComponent<Buy>().targetSpot = this;
        upgradeButton.GetComponent<Upgrade>().targetSpot = this;

        if (SpawnedTower == null)
        {
            if (CanShowBuyButton())
            {
                spawnedBuyButton = Instantiate(buyButton, transform.position + buttonPosition, Quaternion.Euler(75, 0, 0), canvas.transform);
            }
            else if (spawnedBuyButton != null)
            {
                Destroy(spawnedBuyButton);
            }
        }
        else
        {
            if(SpawnedTower.GetComponent<Tower>().IsUpgradedVersion == false)
            {
                if (spawnedUpgradeButton == null)
                {
                    spawnedUpgradeButton = Instantiate(upgradeButton, transform.position + buttonPosition, Quaternion.Euler(75, 0, 0), canvas.transform);
                }
                else
                {
                    Destroy(spawnedUpgradeButton);
                }
            }
        }
    }

    private bool CanShowBuyButton()
    {
        return IsBuyButtonVisible() == false;
    }

    private bool IsBuyButtonVisible()
    {
        return spawnedBuyButton != null;
    }

    void OnMouseEnter()
    {
        if (GameManager.gameIsOver || GameManager.gameIsPaused)
        {
            this.enabled = false;
            return;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
