using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 600;

    public static int lives;
    public int startLives = 20;

    public Text textMoney;
    public Text textLives;

    void Start ()
    {
        money = startMoney;
        lives = startLives;

        textMoney.text = "Money: " + PlayerStats.money;
        textLives.text = "Lives: " + PlayerStats.lives;
    }
    void Update()
    {
        textMoney.text = "Money: " + PlayerStats.money;
        textLives.text = "Lives: " + PlayerStats.lives;
    }
}
