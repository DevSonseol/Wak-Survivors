using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWandBullet : Bullet
{

    void Start()
    {

    }

    protected override void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public override void Shoot(Vector3 dir)
    {
        direction = new Vector3(dir.x,dir.y,0);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        Invoke("DestroyBullet", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Invoke("DestroyBullet", 0f);
            //충돌 후 데미지 주기
            Debug.Log("MagicWandBullet OnTriggerEnter2D 몬스터 충돌");
        }
    }



}
