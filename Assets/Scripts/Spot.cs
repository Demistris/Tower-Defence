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
        buyButton.GetComponent<Buy>().targetSpot = this;

        if (tower != null)
        {
            Debug.Log("Can't build in here!");
            return;
        }

        if (CanShowBuyButton())
        {
            spawnedBuyButton = Instantiate(buyButton, transform.position + buttonPosition, Quaternion.Euler(75, 0, 0), canvas.transform);
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
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
