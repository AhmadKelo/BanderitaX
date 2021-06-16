using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    public Rigidbody2D rb;

    public Animator anim;

    //public GameObject effect;

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
        transform.Rotate(0f, 0f, 10f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        rb.velocity = transform.right * 0;

        anim.Play("BulletExpAnim");
        

        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();

        if (player != null)
        {
            //Stop the Bullet

            player.PlayerDieByHit();

        }

        StartCoroutine(WaitForDestory());
    }

    IEnumerator WaitForDestory()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

    IEnumerator AutoDestory()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
