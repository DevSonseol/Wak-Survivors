using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;

    [SerializeField]
    private float speed = 1;

    public void Shoot(Vector3 dir)
    {
        direction = dir;
        Invoke("DestroyBullet",2f);
    }


    private void DestroyBullet()
    {
        BulletObjectPool.ReturnBullet(this);
    }


    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
