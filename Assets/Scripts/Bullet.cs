using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;

    public int damage = 50;

    public GameObject impactEffect;

	public void Seek (Transform _target)
    {
        target = _target;
	}
	
	void Update ()
    {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        Damage(target);

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        EnemyMovement e = enemy.GetComponent<EnemyMovement>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

}
