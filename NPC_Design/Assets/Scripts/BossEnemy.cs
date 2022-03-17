using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float bossHP = 100f;

    // rotation
    public Transform PlayerTarget;
    public float RotationSpeed = 1f;
    private Coroutine LookCoroutine;

    // Shooting
    public GameObject projectile_Small;
    public Transform projectileSpawnPoint;

    public GameObject shockWave;
    public Transform shockWaveSpawnPoint;

    private void Update()
    {
        StartRotating();
    }

    private void StartRotating()
    {
        StartCoroutine(LookAtPlayer());
    }

    // Rotate the boss to always face toward the player
    private IEnumerator LookAtPlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(PlayerTarget.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * RotationSpeed;

            yield return null;
        }
    }


    public void ShootSmallProjectile()
    {
        Instantiate(projectile_Small, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
    }

    public void UseShockWave()
    {
        Instantiate(shockWave, shockWaveSpawnPoint.transform.position, shockWaveSpawnPoint.transform.rotation);
    }
}
