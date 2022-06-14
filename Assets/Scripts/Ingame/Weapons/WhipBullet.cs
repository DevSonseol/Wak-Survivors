using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipBullet : MonoBehaviour
{
    [SerializeField]
    private float damage;


    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

            //�浹 �� ������ �ֱ�
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<Monster>().TakeDamage(damage);

        }

    }

}
