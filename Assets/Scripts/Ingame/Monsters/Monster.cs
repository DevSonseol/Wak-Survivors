using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterCategory
{

   Bat,Bird,Dog,Fox,Germ,Rani

}

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterCategory monsterCategory;

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float HP;

    [SerializeField]
    private float damage;

    [SerializeField]
    private bool CanDamage = true;

    [SerializeField]
    private float speed = 10; //�ӽ� ���ǵ�

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody2D rigid2D;
    private SpriteRenderer sr;

    [SerializeField]
    public Vector3 velo;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        velo = rigid2D.velocity;
    }

    void Start()
    {
        ChangeSprite();

        if (target == null)
            target = GameObject.Find("Player");

        InvokeRepeating("ChangeSprite",1,0.5f);
    }

  
    void Update()
    {
        if(HP <= 0)
        {
            //���ó��
            Debug.Log("Monster ���ó��");
            this.Die();
        }

 
        ChaseTarget();
    }

    void ChaseTarget()
    {
        if (target == null) //Ÿ���� ������ ����
            return;

        moveDirection = target.transform.position - transform.position; //���⺤��
      
        rigid2D.MovePosition(transform.position + moveDirection.normalized * Time.deltaTime * speed);
    }

    void PushOut() //�ӽ÷� ����
    {
        if (target == null) //Ÿ���� ������ ����
            return;

        moveDirection = target.transform.position - transform.position; //���⺤��

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
            //�÷��̾� ������


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
            //�÷��̾� ������
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

    public void SetMonster(MonsterCategory MC)
    {
        monsterCategory = MC;
    }


    void ChangeSprite()
    {
        switch (monsterCategory)
        {
            case MonsterCategory.Bat:

                if (sr.sprite != sprites[0])
                    sr.sprite = sprites[0];
                else
                    sr.sprite = sprites[1];

                break;
            case MonsterCategory.Bird:

                if (sr.sprite != sprites[2])
                    sr.sprite = sprites[2];
                else
                    sr.sprite = sprites[3];

                break;
            case MonsterCategory.Dog:

                if (sr.sprite != sprites[4])
                    sr.sprite = sprites[4];
                else
                    sr.sprite = sprites[5];

                break;
            case MonsterCategory.Fox:

                if (sr.sprite != sprites[6])
                    sr.sprite = sprites[6];
                else
                    sr.sprite = sprites[7];

                break;
            case MonsterCategory.Germ:

                if (sr.sprite != sprites[8])
                    sr.sprite = sprites[8];

                transform.Rotate(new Vector3(0, 0, 5));

                break;
            case MonsterCategory.Rani:

                if (sr.sprite != sprites[9])
                    sr.sprite = sprites[9];
                else
                    sr.sprite = sprites[10];


                break;

        }
    }
}
