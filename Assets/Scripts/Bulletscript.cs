using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    float bulletspeed=5f;

    [SerializeField]
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
    Vector2 direction = (target.position - transform.position).normalized;

    rigid.velocity =direction*bulletspeed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
