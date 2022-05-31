using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighteningBullet : Bullet
{

    public Sprite[] sparks;

    private SpriteRenderer sr;


    private void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    protected override void Update()
    {

    }

    public void Shoot(Monster targetMonster)
    {
        //�̹��� ����
        int rand = Random.Range(0, 8);
        sr.sprite = sparks[rand];

        //��ġ �̵�
        transform.position = targetMonster.transform.position;
        Invoke("DestroyBullet", duration);

        //���� �Ҹ�

        //Ÿ�ٿ� ������
        targetMonster.TakeDamage(damage);
    }







}
