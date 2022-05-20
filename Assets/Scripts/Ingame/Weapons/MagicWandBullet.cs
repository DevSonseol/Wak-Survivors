using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandBullet : Bullet
{

    [SerializeField]
    private float damage;

    [SerializeField]
    private Vector3 dir;

    [SerializeField]
    private float speed;

    private Transform transform;

    void Start()
    {
        transform = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ºÎµúÈù Àû¿¡°Ô µ¥¹ÌÁö   
    }

}
