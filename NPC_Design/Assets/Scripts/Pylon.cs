using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon : MonoBehaviour
{
    public GameObject pylonProjectile;
    public Transform pylonProjectileSpawnPoint;
    private BoxCollider pylonCollider;
    
    void Start()
    {
        pylonCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Pylon shoot projectile");
            Instantiate(pylonProjectile, pylonProjectileSpawnPoint.position, Quaternion.identity);
            pylonCollider.enabled = false;
            print("disable pylon collider");
        }
    }
}
