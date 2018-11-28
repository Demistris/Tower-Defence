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
    public GameObject tower;
    private GameObject spawnedBuyButton;
    public GameObject upgradeButton;
    private GameObject spawnedUpgradeButton;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    int tmp = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        buyButton.GetComponent<Buy>().targetSpot = this;

        if (tower != null)
        {
            if(tmp == 0)
            {
                spawnedUpgradeButton = Instantiate(upgradeButton, transform.position + buttonPosition, Quaternion.Euler(75, 0, 0), canvas.transform);
                tmp = 1;
            }

            else if (spawnedUpgradeButton != null)
            {
                Destroy(spawnedUpgradeButton);
                tmp = 0;
            }
        }

        if(spawnedUpgradeButton == null)
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
        if (GameManager.gameIsOver)
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
