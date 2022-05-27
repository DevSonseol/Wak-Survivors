using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaWaterBullet : Bullet
{
    [SerializeField]
    private GameObject paticle;

    private Vector3 dest;

    private float rotateZ;

    private bool isInDest;

    private float damageTime = 1f; // �������� �� ������ (�� �����Ӹ��ٰ� �ƴ� ���� �ð����� �������� �ֱ� ���Ͽ�)
    private float currentDamageTime;

    void Start()
    {
    }

    protected override void Update()
    {

        if(transform.position.y < dest.y && !isInDest)
        {
            isInDest = true;
            paticle.SetActive(true);
            Invoke("DestroyBullet", duration);
            return;
        }
        else if(!isInDest)
        {
            //ȸ��
            rotateZ += 5;
            transform.rotation = Quaternion.Euler(0, 0, rotateZ);

            //�̵�
            Vector3 move = direction * speed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }

        if (isInDest && currentDamageTime > 0)
        {
            currentDamageTime -= Time.deltaTime;
        }

    }

    public override void Shoot(Vector3 dir)
    {
        currentDamageTime = 0;
        paticle.SetActive(false);
        isInDest = false;
        direction = new Vector3(dir.x , dir.y, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isInDest)
            return;

        if (collision.gameObject.tag == "Monster")
        {

            if(currentDamageTime <= 0)
            {
                //�浹 �� ������ �ֱ�
                Debug.Log(collision.name);
                collision.gameObject.GetComponent<Monster>().TakeDamage(damage);
                StartCoroutine(ResetDamageTime());
            }

        }

    }

    private IEnumerator ResetDamageTime()
    {
        yield return null;
        currentDamageTime = damageTime; 
    }

    public void SetDestination(Vector3 _dest)
    {
        dest = _dest;

    }

}
