using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float bossHP = 100f;
    public float damageReceived = 25f;

    // Shooting
    public GameObject projectile_Small;
    public Transform projectileSpawnPoint;

    public ShockWaveSpawner shockWaveSpawner;

    public void ShootSmallProjectile()
    {
        Instantiate(projectile_Small, projectileSpawnPoint.transform.position, 
            projectileSpawnPoint.transform.rotation);
    }

    public void UseShockWave()
    {
        shockWaveSpawner = GameObject.FindGameObjectWithTag("ShockWaveSpawner").GetComponent<ShockWaveSpawner>();
        shockWaveSpawner.UseShockWave();
    }

    // Projectile from the pylons will damage the boss and decease its HP
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PylonProjectile"))
        {
            // do damage to boss
            bossHP = bossHP - damageReceived;
            print("hit by pylon projectile");
            Destroy(other.gameObject);
            print(bossHP);
        }
    }
}
