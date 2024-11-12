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
    [SerializeField]
    Transform gunrotation;
    float timeBetweenShots = 2.5f;
    float timeSinceLastShot = 0;

    void Start(){



    }
    // Update is called once per frame
    void Update()
    {
        transform.right = gunposition.position - transform.position;
        Quaternion Rotation = Quaternion.LookRotation(transform.right);
        print(Rotation);
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= timeBetweenShots)
        {
            Instantiate(ShotPrefab, gunposition.position, Rotation);
            timeSinceLastShot = 0;
        }

    }
}
