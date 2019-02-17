using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public float startHealth;
    private float health;
    public int value;

    public GameObject deathEffect;

    public Image healthBar;

    private Transform target;
    private int wavePointIndex = 0;

    private bool isDead = false;

    public AudioSource losingLifeSoundPrefab;

    void Start ()
    {
        target = Waypoints.points[0];
        health = startHealth;
	}

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        PlayerStats.money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject); 
    }
	
	
	void Update ()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
	}

    void GetNextWaypoint()
    {
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayLosingLifeSound();
        PlayerStats.lives--;
        Destroy(gameObject);
    }

    public void PlayLosingLifeSound()
    {
        AudioSource losingLifeSoundInstance = Instantiate(losingLifeSoundPrefab);
        losingLifeSoundInstance.Play();
    }
}
