using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoBullet : MonoBehaviour
{

    public float speed = 30f;
    public Rigidbody2D rb;

    Animator anim;

    public int damage;
    void Start()
    {
        rb.velocity = transform.right * speed;

        anim = GetComponent<Animator>();

        StartCoroutine(AutoDestory());
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, -15f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(!hitInfo.CompareTag("Potato") && !hitInfo.CompareTag("Controller")){
    
        rb.velocity = transform.right * 0;

        anim.Play("BulletExpAnim");
        StartCoroutine(WaitForAnimation());

        }

        if(hitInfo.CompareTag("Enemy")){
  
            EnemyScript enemy =  hitInfo.GetComponent<EnemyScript>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }       
        }

        
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    IEnumerator AutoDestory()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
