using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Start()
    {
        //첫번쨰꺼 작동
        CanCast = true;
    }

    void Update()
    {
        //플레이어 위치로 이동
        transform.position = player.transform.position;


        if (CanCast)
        {
            CanCast = false;
            //공격
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {

        for (int i = 0; i < bulletCount; i++)
        {
            yield return new WaitForSeconds(castdelayTime);
            Shoot();
            Debug.Log("나이프");
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * bulletCount));

        CanCast = true;

    }


    private void Shoot()
    {
        Vector3 dir = player.GetComponent<Player>().playerDir;

        var bullet = ObjectPool.GetBullet(BulletCategory.Knife);
        bullet.transform.position = transform.position + dir.normalized;
        bullet.SetBulletStat(damage, duratation, speed);
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
