using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    void Update()
    {
        transform.right = target.position - transform.position;
    }
}
