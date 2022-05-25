using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : Weapon
{
    private const int maxWhipCount = 4;
    private const float castdelayTinme = 0.15f;

    [SerializeField]
    private GameObject[] whips;

    [SerializeField]
    private bool[] isActive = new bool[4];

    [SerializeField]
    //private string[] desc = new string[8];

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Start()
    {
        //첫번쨰꺼 작동
        CanCast = true;
        isActive[0] = true;
    }

    void Update()
    {
        //플레이어 위치로 이동
        transform.position = player.transform.position;
        if (player.transform.localScale.x > 0)
            transform.transform.localScale = new Vector3(1, 1, 1);
        else
            transform.transform.localScale = new Vector3(-1, 1, 1);


        if (CanCast)
        {
            StartCoroutine(Active());
        }

    }

    private IEnumerator Active()
    {
        CanCast = false;

        for (int i = 0; i < isActive.Length; i++)
        {
            if(isActive[i])
            {
                StartCoroutine(FadeIn(whips[i]));
            }
            yield return new WaitForSeconds(castdelayTinme);
            Debug.Log("whip");
        }

        yield return new WaitForSeconds(coolTime-( castdelayTinme* maxWhipCount));
        Debug.Log("cool");

        CanCast = true;
    }


    private IEnumerator FadeIn(GameObject go)
    {
        go.SetActive(true);
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        Color color = sr.material.color;
        color.a = 0;

        while (color.a < 1)
        {
            color.a += Time.deltaTime / duration;
            sr.material.color = color;
            yield return new WaitForSeconds(Time.deltaTime / duration);
        }

        color.a = 0;
        go.SetActive(false);
    }

    public override void LevelUp()
    {
        if(Level < MaxLevel)
        {
            Level++;
            
            switch(Level)
            {
                case 1:
                    isActive[0] = true;
                    break;
                case 2:
                    damage+=5;
                    break;
                case 3:
                    isActive[1] = true;
                    break;
                case 4:
                    damage += 5;
                    break;
                case 5:
                    isActive[2] = true;
                    break;
                case 6:
                    damage += 10;
                    break;
                case 7:
                    isActive[3] = true;
                    break;
                case 8:
                    damage += 10;
                    CanEvolve = true;
                    break;
            }

        }
    }


}
