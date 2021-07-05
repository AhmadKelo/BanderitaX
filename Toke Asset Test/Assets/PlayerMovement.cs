using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 myPosition;
    [SerializeField] float speed;

    Animator anim;

    Rigidbody2D rb;

    bool isJumping = false;
    void Start()
    {
         anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if(Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        anim.SetFloat("Speed", Mathf.Abs(myPosition.x));


        if(Input.GetKey(KeyCode.W) && !isJumping)
        {
            rb.velocity = new Vector2(0 , 15f);
            anim.SetBool("IsJumping", true);
            isJumping = true;
        }

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isJumping = false;
            anim.SetBool("IsJumping", false);
        }


        if(Input.GetMouseButton(0))
        {
            anim.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        myPosition.x = Input.GetAxisRaw("Horizontal");
        transform.position += myPosition * speed * Time.deltaTime;
    }
}
