using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Small : MonoBehaviour
{
    private Rigidbody rb;
    public float projectile_SmallSpeed = 50f;

    public Transform playerTransform;
    private Vector3 playerDelayedTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerTransform = GameObject.FindGameObjectWithTag("ProjectileTarget").transform;
        playerDelayedTransform = new Vector3(playerTransform.position.x, 
            playerTransform.position.y, playerTransform.position.z);
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerDelayedTransform,
            projectile_SmallSpeed * Time.deltaTime);

        if (transform.position == playerDelayedTransform)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cover"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            // do damage
            print("Hit Player");
            Destroy(gameObject);
        }
    }
}
