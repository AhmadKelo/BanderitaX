using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    public Rigidbody2D rb;

    public Animator anim;

    void Start()
    {
        //Move the Bullet
        rb.velocity = transform.right * speed;

        anim = GetComponent<Animator>();

        StartCoroutine(AutoDestory());
    }

    void FixedUpdate()
    {
        //Rotate the Bullet
        transform.Rotate(0f, 0f, 10f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(!hitInfo.CompareTag("Controller"))
        {

        //Stop the Bullet
        rb.velocity = transform.right * 0;

        //Play Explode Animation
        anim.Play("BulletExpAnim");
        

        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.PlayerHit();
        }
        }
        //Destroy Bullet When Animaiton Done
        Destroy(gameObject, 0.25f);

    }

    //When Bullet Didn't Hit Anything Auto Destroy
    IEnumerator AutoDestory()
    {
        yield return new WaitForSeconds(8f);
        if(gameObject != null)
        Destroy(gameObject);
    }
}
