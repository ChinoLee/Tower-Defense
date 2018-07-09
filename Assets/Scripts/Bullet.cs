﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 50;
    public float speed = 20;

    public GameObject explosionEffectPrefabs;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    void Update()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            GameObject.Instantiate(explosionEffectPrefabs, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}