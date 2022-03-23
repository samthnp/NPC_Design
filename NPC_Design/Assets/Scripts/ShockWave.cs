using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    private Rigidbody rb;
    public float shockWaveSpeed;

    public Transform playerTransform;
    private Vector3 playerDelayedTransform;
    
    public float lifeTime;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerTransform = GameObject.FindGameObjectWithTag("ShockWaveTarget").transform;
        playerDelayedTransform = new Vector3(playerTransform.position.x,
            playerTransform.position.y, playerTransform.position.z);
        
        Invoke("DestroyShockWave", lifeTime);
    }
    
    void Update()
    {
        /*transform.position = Vector3.MoveTowards(transform.position, playerDelayedTransform,
            shockWaveSpeed * Time.deltaTime);*/
        
        transform.Translate(transform.forward * shockWaveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // do damage
            print("Shockwave Hit");
            DestroyShockWave();
        }
    }


    void DestroyShockWave()
    {
        Destroy(gameObject);
    }
    
}
