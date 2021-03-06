using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
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
        //ù?????? ?۵?
        CanCast = true;
    }

    void Update()
    {
        //?÷??̾? ??ġ?? ?̵?
        transform.position = player.transform.position;


        if (CanCast)
        {
            CanCast = false;
            //????
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            yield return new WaitForSeconds(castdelayTime);
            Shoot();
        }


        yield return new WaitForSeconds(coolTime - (castdelayTime * bulletCount));

        CanCast = true;
    }


    private void Shoot()
    {
        if (MonsterPool.Instance.nerestTarget == null)
            return;

        Vector3 dir = MonsterPool.Instance.nerestTarget.transform.position - player.transform.position;
        dir.y = 0;
        dir.z = 0;

        var bullet = ObjectPool.GetBullet(BulletCategory.Axe);
        bullet.transform.position = transform.position;
        bullet.SetDamage(damage);
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
