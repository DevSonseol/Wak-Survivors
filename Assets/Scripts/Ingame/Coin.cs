using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float EXP;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float speed = 5;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
    }

  
    void Update()
    {
        if (target == null) //Å¸°ÙÀÌ ¾øÀ¸¸é ¸®ÅÏ
            return;

        moveDirection = target.transform.position - transform.position; //¹æÇâº¤ÅÍ
        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        float dist = Vector3.Distance(target.transform.position,transform.position);

        if(dist < 0.1f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(target != null)
            return;
        
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("ÀÌºÁ Â¡Â¡ÀÌ µ¿ÀüÁ»");

            target = collision.gameObject;
        }

    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("ÀÌºÁ Â¡Â¡ÀÌ µ¿ÀüÁ»");

    //    target = collision.collider.gameObject;
    //}





}
