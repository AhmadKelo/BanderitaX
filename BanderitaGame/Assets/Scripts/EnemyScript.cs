using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health = 100;

    public Animator anim;

    public AudioSource braaLooseSound;
    public AudioSource braaHitSound;

    private Transform target; // Player

    public float speed = 5f; // Moving Speed

    BoxCollider2D bc2d; // For Disabling Collider when Loose
    bool lost;

    void Start()
    {
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();

        target = GameObject.Find("Player").GetComponent<Transform>();

        anim.Play("BraaMoveAnim");
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 8f && !lost)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

    public void TakeDamage(int damage)
    {
        if(!lost)
        {
        health -= damage;
        
        anim.Play("TakeDamageAnim");

        braaHitSound.Stop();
        braaHitSound.Play();

        if(health <= 0)
        {
            DisAppear();
            
        }
        }
    }

    void DisAppear()
    {
        braaLooseSound.Play();
        //anim.Play("BraaLooseAnim");
        lost = true;
        bc2d.enabled = false;
    }
}
