using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
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
        Debug.Log("Trigger");
        bulletBehavior();
        destroyTarget(other);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        bulletBehavior();
    }

    private void bulletBehavior()
    {
        collision++;
        Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
        rigidbody.velocity = transform.forward * moveSpeed * Time.deltaTime;
        if (collision >= maxCollision)
        {
            Destroy(gameObject);
        }
    }

    private void destroyTarget(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            var targetTransform = other.transform;
            Destroy(other.gameObject);
            Instantiate(impactEffect, targetTransform.position, targetTransform.rotation);

        }
    }
    
}
