using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWandBullet : Bullet
{


    private float degree;

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
        var quaternion = Quaternion.Euler(0, 0, degree);
        direction = quaternion * direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

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

    public void SetDegree(float _degree)
    {
        degree = _degree;
    }

}
