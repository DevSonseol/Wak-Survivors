using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pentagram : Weapon
{

    private SpriteRenderer sr;

    [SerializeField]
    private Text text;

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

    }

    void Update()
    {
        //�÷��̾� ��ġ�� �̵�
        transform.position = player.transform.position;


        if (CanCast)
        {
            CanCast = false;
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        //��� ���Ϳ��� ������
        GameObject monsterpool = MonsterPool.Instance.gameObject;
        Monster[] monsters = monsterpool.GetComponentsInChildren<Monster>();

        foreach(Monster mon in monsters)
        {
            mon.Die();
        }

        yield return new WaitForSeconds(coolTime);
        CanCast = true;
    }

    void FadeIn()
    {
        //��� 



    }

    void FadeOut()
    {
        //��� 

      

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
