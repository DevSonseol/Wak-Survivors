using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer sr;

    [SerializeField]
    private int EXP = 1;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float speed = 5;

    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetCoin(int exp)
    {
        EXP = exp;

        switch (exp)
        {
            case 1:
                sr.sprite = sprites[0];
                break;
            case 2:
                sr.sprite = sprites[1];
                break;
            case 3:
                sr.sprite = sprites[2];
                break;
            case 4:
                sr.sprite = sprites[3];
                break;
            case 5:
                sr.sprite = sprites[4];
                break;
        }

    }

    void Start()
    {

    }

    void Update()
    {
        MovingToTarget();
    }

    void MovingToTarget()
    {
        if (target == null) //Ÿ���� ������ ����
            return;

        moveDirection = target.transform.position - transform.position; //���⺤��
        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        float dist = Vector3.Distance(target.transform.position, transform.position);

        if (dist < 0.1f)
        {
            PlayerData.Instance.GainCoin(EXP);
            ReturnToPooling();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(target != null)
            return;
        
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("�̺� ¡¡�� ������");

            target = collision.gameObject;
        }
    }

    public void ReturnToPooling()
    {
        CoinPool.ReturnCoin(this);
    }

}
