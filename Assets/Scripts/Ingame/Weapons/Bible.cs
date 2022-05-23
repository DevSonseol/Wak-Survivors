using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : Weapon
{

    [SerializeField]
    private float distFromPlayer;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Start()
    {
        //ù������ �۵�
        CanCast = true;
    }

    void Update()
    {
        //�÷��̾� ��ġ�� �̵�
        transform.position = player.transform.position;


        if (CanCast)
        {
            CanCast = false;
            //����
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        float degree = 360 / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            yield return new WaitForSeconds(castdelayTime);

            Shoot(distFromPlayer,degree * i);
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * bulletCount));

        CanCast = true;
    }


    private void Shoot(float dist, float degree)
    {
        if (MonsterPool.Instance.nerestTarget == null)
            return;

        Vector3 dir = MonsterPool.Instance.nerestTarget.transform.position - player.transform.position;

        var bullet = ObjectPool.GetBullet(BulletCategory.Bible) as BibleBullet;
        bullet.transform.position = transform.position;

        bullet.SetBulletStat(damage, duratation, speed);
        bullet.SetDistFromPlayerAndDegree(distFromPlayer, degree);

        bullet.Shoot(dir.normalized);
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
