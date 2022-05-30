using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighteningBullet : Bullet
{

    [SerializeField]
    private Sprite[] sparks;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {

    }

    public void Shoot(Vector3 dir , Monster targetMonster)
    {
        //�̹��� ����
        int rand = Random.Range(0, sparks.Length);
        sr.sprite = sparks[rand];

        direction = new Vector3(dir.x, dir.y, 0);
        Invoke("DestroyBullet", duration);

        //���� �Ҹ�

        //Ÿ�ٿ� ������
        targetMonster.TakeDamage(damage);
    }







}
