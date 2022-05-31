using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pentagram : Weapon
{

    private SpriteRenderer sr;

    [SerializeField]
    private Text text;


    private CircleCollider2D cc;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        CanCast = true;
    }
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        cc = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        //플레이어 위치로 이동
        transform.position = player.transform.position;

        if (CanCast)
        {
            cc.radius = 0.1f;
            CanCast = false;
            StartCoroutine(Active());
        }
    }

    private IEnumerator Active()
    {
        ////모든 몬스터에게 데미지
        //GameObject monsterpool = MonsterPool.Instance.gameObject;
        //Monster[] monsters = monsterpool.GetComponentsInChildren<Monster>();

        //foreach(Monster mon in monsters)
        //{
        //    mon.Die();
        //}

        cc.radius += Time.deltaTime / 2;

        yield return new WaitForSeconds(coolTime);
        CanCast = true;
    }

    void FadeIn()
    {
        //잠깐 


    }

    void FadeOut()
    {
        //잠깐 


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().Die();
        }
    }


    public override void LevelUp()
    {
        if (Level < MaxLevel)
        {
            Level++;

            switch (Level)
            {
                case 1:
                    damage = 5;
                    bulletCount = 1;
                    break;
                case 2:
                    damage += 3;
                    break;
                case 3:
                    bulletCount++;
                    break;
                case 4:
                    damage += 4;
                    break;
                case 5:
                    bulletCount++;
                    break;
                case 6:
                    damage += 5;
                    break;
                case 7:
                    bulletCount++;
                    break;
                case 8:
                    damage += 5;
                    CanEvolve = true;
                    break;
            }

        }
    }
}
