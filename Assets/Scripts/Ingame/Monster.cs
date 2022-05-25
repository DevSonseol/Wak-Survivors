using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float HP;

    [SerializeField]
    private float damage;

    [SerializeField]
    private bool CanDamage = true;

    [SerializeField]
    private float speed = 10; //임시 스피드

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody2D rigid2D;

    [SerializeField]
    public Vector3 velo;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        velo = rigid2D.velocity;
    }

    void Start()
    {
        if(target == null)
            target = GameObject.Find("Player");

    }

  
    void Update()
    {
        if(HP <= 0)
        {
            //사망처리
            Debug.Log("Monster 사망처리");
            this.Die();
        }


        ChaseTarget();
    }

    void ChaseTarget()
    {
        if (target == null) //타겟이 없으면 리턴
            return;

        moveDirection = target.transform.position - transform.position; //방향벡터
      
        rigid2D.MovePosition(transform.position + moveDirection.normalized * Time.deltaTime * speed);
    }

    void PushOut() //임시로 만듬
    {
        if (target == null) //타겟이 없으면 리턴
            return;

        moveDirection = target.transform.position - transform.position; //방향벡터

        rigid2D.MovePosition(transform.position + -moveDirection.normalized * Time.deltaTime * speed*3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CanDamage)
            return;

        if (collision.collider.gameObject.GetComponent<Player>() == null)
        {
            return;
        }
        else
        {
            //Debug.Log("HitPlayer");

            CanDamage = false;
            //플레이어 데미지


            StartCoroutine(AttackDelay());
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!CanDamage)
            return;

        if (collision.collider.gameObject.GetComponent<Player>() == null)
        {
            return;
        }
        else
        {
            //Debug.Log("HittingPlayer");

            CanDamage = false;
            //플레이어 데미지
            target.GetComponent<Player>().Get_Damage(damage);


            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        CanDamage = true;
    }

    public void TestChangeColor(Color color)
    {
        SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();

        renderer.color = color;



    }

    public void Die()
    {
        MonsterPool.ReturnMonster(this);
    }

    public void TakeDamage(float Damage)
    {
        HP -= Damage;
    }

    public void SetMonster(float HP,float Damage,float Speed)
    {
        this.HP = HP;
        this.damage = Damage;
        this.speed = Speed;
    }

}
