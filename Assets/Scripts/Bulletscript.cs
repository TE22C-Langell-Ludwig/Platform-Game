using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    float bulletspeed = 5f;

    Vector2 direction;

    [SerializeField]
    Transform target;
    // Start is called before the first frame update
    void Start()
    {   
        GameObject Player = GameObject.Find("Akechi mitsuhide");
        target = Player.transform;
        Vector3 targetedposition = target.position;
        direction = (targetedposition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = direction * bulletspeed;
    }
     private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Ground")
        {
        Destroy(this.gameObject);
        }
        else if (Other.tag == "Player")
        {
        Destroy(this.gameObject);
        }
    }
}
