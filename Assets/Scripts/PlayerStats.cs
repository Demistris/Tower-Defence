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
    public Text textWaves;

    public Spawner spawner;

    public static int rounds;

    void Start ()
    {
        money = startMoney;
        lives = startLives;

        textMoney.text = "Money: " + PlayerStats.money;
        textLives.text = "Lives: " + PlayerStats.lives;
        textWaves.text = "Wave: " + spawner.countWaves + " / " + spawner.waves.Length;

        rounds = 0;
    }
    void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        textMoney.text = "Money: " + PlayerStats.money;
        textLives.text = "Lives: " + PlayerStats.lives;
        textWaves.text = "Wave: " + spawner.countWaves + " / " + spawner.waves.Length;
    }
}
