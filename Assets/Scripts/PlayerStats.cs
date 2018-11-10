using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 1000;

    void Start ()
    {
        money = startMoney;
	}
}
