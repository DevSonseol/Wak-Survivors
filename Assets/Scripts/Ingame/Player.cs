using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerCharacter
{
    Wak,Ine,Jingburger,Lilpa,Jururu,Gosegu,Viichan
}

public class Player : MonoBehaviour
{
    private const float normalSize = 0.5f;


    [SerializeField]
    private Weapon[] weapons = new Weapon[6];

    //private bool isMaxWeapons = false;

    [SerializeField]
    private Power[] powers = new Power[6];

    //private bool isMaxPowers = false;



    //player 설정 할 것들

    [SerializeField]
    private float HP;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rigid2D;
    private Animator animator;

    void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveSpeed = PlayerData.Instacne.Stat.MoveSpeed;
        HP = PlayerData.Instacne.Stat.MaxHealth;
        maxHP = PlayerData.Instacne.Stat.MaxHealth;

        circleCollider2D.radius = normalSize * PlayerData.Instacne.Stat.Magnet;
    }


    void Update()
    {
        if (HP <= 0)
            return;



        Input_MovePlayer();
    }

    public void Input_MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        bool isMove = false;
        
        if(x !=0 || y !=0)
        {
            isMove = true;
            rigid2D.velocity = new Vector3(x, y, 0).normalized * moveSpeed;
        }else
        {
            rigid2D.velocity = new Vector3(0, 0, 0);
        }
               
        animator.SetBool("isMove", isMove);

        //방향에 따라 이미지 좌우 반전해주기
        if (x < 0)
        {
            this.transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        else if (x > 0)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }

    }

    public void Get_Damage(float damage)
    {
        HP -= damage;
    }








}
