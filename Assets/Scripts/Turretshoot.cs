using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Turretshoot : MonoBehaviour
{
    [SerializeField]
    Transform gunposition;
    [SerializeField]
    GameObject ShotPrefab;
    float timeBetweenShots = 2f;
    float timeSinceLastShot = 0;

    void Start(){
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= timeBetweenShots)
        {
            Instantiate(ShotPrefab, gunposition.position, quaternion.identity);
            timeSinceLastShot = 0;
        }

    }
}
