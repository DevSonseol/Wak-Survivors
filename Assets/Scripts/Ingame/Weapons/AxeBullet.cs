using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBullet : Bullet
{

    [SerializeField]
    private float force;

    private const float fixedforce = 18;

    [SerializeField]
    private float gravity;

    private float rotateZ;
    void Start()
    {

    }

    protected override void Update()
    {
        //ȸ��
        rotateZ += 5;
        transform.rotation = Quaternion.Euler(0,0, rotateZ);

        //�̵�
        force -= gravity * Time.deltaTime;//���� ������
        Vector3 move = new Vector3(speed * direction.x, force, 0) * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    public override void Shoot(Vector3 dir)
    {
        //�߷� �ʱ�ȭ
        ResetForce();
        //�������� ��¦ ��߳���
        float random = Random.Range(0f, 2f);

        direction = new Vector3(dir.x * random, dir.y, 0);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
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
            Debug.Log("AxeBullet OnTriggerEnter2D ���� �浹");
            collision.GetComponent<Monster>().Die();
        }
    }

    private void ResetForce()
    {
        force = fixedforce;
        force -= Random.Range(0f, 5f);
        
    }
}
