using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : Weapon
{
    private bool colorSwitch;

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

        for (int i = 0; i < bulletCount; i++)
        {

            Shoot(new Vector3(1, 1, 0));

            Shoot(new Vector3(1, -1, 0));

            Shoot(new Vector3(-1, 1, 0));

            Shoot(new Vector3(-1, -1, 0));

            colorSwitch = !colorSwitch;
            yield return YieldInstructionCache.WaitForSeconds(castdelayTime);
        }

        yield return new WaitForSeconds(coolTime - (bulletCount * castdelayTime));

        CanCast = true;
    }


    private void Shoot(Vector3 dir)
    {
        var bullet = ObjectPool.GetBullet(BulletCategory.Gun) as GunBullet;
        bullet.transform.position = transform.position;
        bullet.SetBulletStat(damage, duration, speed);
        if (colorSwitch)
            bullet.SetColor(Color.red);
        else
            bullet.SetColor(Color.blue);
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
