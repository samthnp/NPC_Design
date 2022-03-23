using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMesh : MonoBehaviour
{
    // rotation
    public Transform PlayerTarget;
    public float RotationSpeed = 1f;
    private Coroutine LookCoroutine;
    
    private void Update()
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
}
