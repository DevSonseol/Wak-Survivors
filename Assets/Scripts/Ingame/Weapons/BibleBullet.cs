using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleBullet : Bullet
{

    [SerializeField]
    private float distFromPlayer;

    private float degree;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    protected override void Update()
    {
        //����
        MoveAround();
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
            //�浹 �� ������ �ֱ�
            Debug.Log("AxeBullet OnTriggerEnter2D ���� �浹");
            collision.GetComponent<Monster>().Die();
        }
    }


    private void MoveAround()
    {
        degree += speed * Time.deltaTime;

        Vector3 direction = transform.up; 

        var quaternion = Quaternion.Euler(0, 0, degree);
        Vector3 newDirection = quaternion * direction;

        transform.position = player.transform.position + distFromPlayer * newDirection;

    }


    public void SetDistFromPlayerAndDegree(float dist,float _degree)
    {
        distFromPlayer = dist;
        degree = _degree;
    }
}
