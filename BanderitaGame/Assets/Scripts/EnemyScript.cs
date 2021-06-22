using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public Animator anim;

    public AudioSource braaLooseSound;
    public AudioSource braaHitSound;

    private Transform target; // Player

    public float speed = 5f; // Moving Speed

    BoxCollider2D bc2d; // For Disabling Collider when Loose
    bool lost;

    SpriteRenderer sp;

    public HealthBarScript healthBar;

    public GameObject door;
    public GameObject braaHealthBar;

    bool isEngaged;

    float distance = 9f;
    void Start()
    {
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();

        target = GameObject.Find("Player").GetComponent<Transform>();

        anim.Play("BraaMoveAnim");
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > distance && !lost)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if(transform.position.x > target.position.x)
        {
            transform.eulerAngles = new Vector3 (0f,0f,0f);
            sp.flipX = false;
        }else if(transform.position.x < target.position.x)
        {
            transform.eulerAngles = new Vector3 (0f,180f,0f);
            sp.flipX = true;
        }

        if(transform.position.y < -5f)
        {
            TakeDamage(100);
            lost = true;
        }
    }

    public void TakeDamage(float damage)
    {
        if(!lost)
        {
        currentHealth -= damage;
        
        anim.Play("TakeDamageAnim");

        braaHitSound.Play();
        healthBar.SetHealth(currentHealth);

        if(currentHealth == 20 || currentHealth == 40 || currentHealth == 60 || currentHealth == 80)
        {
            anim.Play("BraaEngagedAnim");
            anim.SetBool("IsEngaged",true);
            GetComponent<Weapon>().speed = 0.2f;
            StartCoroutine(WaitForEngage());
            distance = distance / 2f;
        }

        if(currentHealth <= 0)
        {
            DisAppear();
            EnemyLoose();
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


    void EnemyLoose()
    {
        door.SetActive(true);
        braaHealthBar.SetActive(false); 
    }

    IEnumerator WaitForEngage()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsEngaged",false);
        GetComponent<Weapon>().speed = 1.4f;
        distance = distance * 2f;
    }
}
