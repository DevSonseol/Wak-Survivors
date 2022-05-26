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
    void Start()
    {

    }

    protected override void Update()
    {

        if(transform.position.y < dest.y && !isInDest)
        {
            isInDest = true;
            paticle.SetActive(true);
            Invoke("DestroyBullet", 2f);
        }
        else
        {
            //회전
            rotateZ += 5;
            transform.rotation = Quaternion.Euler(0, 0, rotateZ);

            //이동
            Vector3 move = direction * speed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }


    }

    public override void Shoot(Vector3 dir)
    {
        isInDest = false;
        direction = new Vector3(dir.x , dir.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster" && isInDest)
        {
            //충돌 후 데미지 주기
            Debug.Log("AxeBullet OnTriggerEnter2D 몬스터 충돌");
            collision.GetComponent<Monster>().Die();
        }
    }

    public void SetDestination(Vector3 _dest)
    {
        dest = _dest;

    }

    protected void DestroyBullet()
    {
        ObjectPool.ReturnBullet(this, this.category);
    }

}
