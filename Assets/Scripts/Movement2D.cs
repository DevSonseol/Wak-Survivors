using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;              //�̵��ӵ�
    private Rigidbody2D rigid2D;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move2D();
    }

    void Move2D() //�÷��̾�� ������ �հ� ���� �ְ� �ӷ��� �̿��Ͽ� �̵�
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rigid2D.velocity = new Vector3(x, y, 0).normalized * moveSpeed;
    }


    public void EditSpeed(float _BaseSpeed, float _Percent)
    {
        moveSpeed = _BaseSpeed + _BaseSpeed * _Percent;
    }

    public void SetSpeed(float _Speed)
    {
        moveSpeed = _Speed;
    }

}
