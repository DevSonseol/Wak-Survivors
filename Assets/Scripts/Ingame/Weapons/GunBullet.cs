using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    protected override void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public override void Shoot(Vector3 dir)
    {
        direction = new Vector3(dir.x, dir.y, 0);
        Invoke("DestroyBullet", duration);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            CancelInvoke("DestroyBullet");

            DestroyBullet();
            //�浹 �� ������ �ֱ�
            Debug.Log("MagicWandBullet OnTriggerEnter2D ���� �浹");
            collision.GetComponent<Monster>().Die();
        }
    }
    
    public void SetColor(Color color)
    {
        sr.color = color;
    }


}
