using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonProjectile : MonoBehaviour
{
    public Transform bossTransform;
    public float pylonProjectileSpeed;
    
    void Start()
    {
        bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bossTransform.position,
            pylonProjectileSpeed * Time.deltaTime);
    }
}
