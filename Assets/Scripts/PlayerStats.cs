using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 1000;

    public Text textMoney;

    void Start ()
    {
        money = startMoney;
        textMoney.text = "Money: " + PlayerStats.money;
    }
    void Update()
    {
        textMoney.text = "Money: " + PlayerStats.money;
    }
}
