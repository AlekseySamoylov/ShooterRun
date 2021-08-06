using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject head;
    private bool alive = true;
    private Rigidbody _rigidbody;
    public int health = 3;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameObject[] childrens = transform.GetComponentsInChildren<GameObject>();
        foreach (var children in childrens)
        {
            if (children.CompareTag("TargetHead"))
            {
                head = children;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && head == null)
        {
            Debug.Log("Register head-shot death");
            simulateDeath();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (alive && other.collider.CompareTag("Bullet"))
        {
            Debug.Log("Register shot");
            health--;
            if (health == 0)
            {
                Debug.Log("Register health death");
                simulateDeath();
            }
        }
    }

    private void simulateDeath()
    {
        alive = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.freezeRotation = false;
    }
}
