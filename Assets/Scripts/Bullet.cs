using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    protected Vector3 direction;

    [SerializeField]
    protected float speed = 1;

    [SerializeField]
    protected BulletCategory category;

    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float duration;

    public virtual void Shoot(Vector3 dir)
    {
        direction = dir;
        Invoke("DestroyBullet", duration);
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
