using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : Weapon
{
    private const int maxBulletCount = 8;
    private const float castdelayTinme = 0.05f;

    [SerializeField]
    private GameObject magicWandBulletPrefab;


    [SerializeField]
    private int bulletCount = 1;


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
        //����� �� Ž��

            //����
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        CanCast = false;

        for (int i = 0; i < maxBulletCount; i++)
        {
            Shoot();
            Debug.Log("shoot");
        }

        yield return new WaitForSeconds(coolTime - (castdelayTinme * maxBulletCount));
        Debug.Log("shootcool");

        CanCast = true;
    }


    private void Shoot()
    {


      
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
