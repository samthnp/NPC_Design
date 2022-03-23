using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShockWaveSpawner : MonoBehaviour
{
    public GameObject shockWave;
    public Transform shockWaveSpawnPoint;

    public void UseShockWave()
    {
        Instantiate(shockWave, shockWaveSpawnPoint.transform.position, quaternion.identity);
        print("Use shockwave");
    }
}
