using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public GameObject impactEffect;
    public int maxCollision = 2;
    private Rigidbody rigidbody;
    private int collision = 0;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = transform.forward * moveSpeed * Time.deltaTime;

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collision++;
        rigidbody.velocity = transform.forward * moveSpeed * Time.deltaTime;
        Instantiate(impactEffect, transform.position, transform.rotation);
        if (collision >= maxCollision)
        {
            Destroy(gameObject);
        }
    }
}
