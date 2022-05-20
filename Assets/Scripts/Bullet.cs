using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected Vector3 direction;

    [SerializeField]
    protected float speed = 1;

    [SerializeField]
    protected BulletCategory category = BulletCategory.testBullet;

    [SerializeField]
    protected float damage;

    public virtual void Shoot(Vector3 dir)
    {
        direction = dir;
        Invoke("DestroyBullet",2f);
    }


    protected void DestroyBullet()
    {
        ObjectPool.ReturnBullet(this, this.category);
    }


    protected virtual void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
