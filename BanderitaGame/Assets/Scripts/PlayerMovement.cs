using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Player Shape
    SpriteRenderer mySprite;

    Rigidbody2D rb;

    Animator anim;

    [SerializeField] float speed = 7f;

    [SerializeField] float jump = 12.5f;

    [SerializeField] Vector3 myPosition;

    public bool isJumping;

    // Spawning
    Vector3 spawnPosition;

    // Audio
    public AudioSource hitSound;

    // Crouch
    public BoxCollider2D bc1;
    public BoxCollider2D bc2;
    public bool isCrouching;

    // Potato
    public GameObject[] potato;

    public int maxHealth;
    public int currentHealth;

    public HealthBarScript healthBar;
    void Start()
    {
        isJumping = false;
        mySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawnPosition = transform.position;

        if(healthBar != null)
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        //Player direction
        if (myPosition.x > 0 && !PauseMenuScript.GameIsPaused)
        {
                transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if (myPosition.x < 0 && !PauseMenuScript.GameIsPaused)
        {
                transform.eulerAngles = new Vector3(0f,180f,0f);
        }


        //Run Animation
        anim.SetFloat("Speed", Mathf.Abs(myPosition.x));

        // Player Lose
        if (transform.position.y < -5f)
        {
            PlayerDieFalling();
        }

        //Crouch
        if (Input.GetKey(KeyCode.S) && !isJumping && !PauseMenuScript.GameIsPaused)
        {
            anim.SetBool("isCrouching", true);
            speed = 4f;
            bc1.enabled = false;
            bc2.enabled = true;
            isCrouching = true;
        }
        else 
        {
            anim.SetBool("isCrouching", false);
            speed = 7f;
            bc1.enabled = true;
            bc2.enabled = false;
            isCrouching = false;
        }


        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && !isJumping && !PauseMenuScript.GameIsPaused)
        {
            rb.velocity = new Vector2(0, jump);
            isJumping = true;
            anim.SetBool("IsJumping", true);
        }
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
                isJumping = false;
                anim.SetBool("IsJumping", false);
        }


    }


    private void FixedUpdate()
    {
        // Walk and Run
        myPosition.x = Input.GetAxisRaw("Horizontal");
        transform.position += myPosition * speed * Time.fixedDeltaTime;


    }

    // When Player Lose By Controller Hit
    public void PlayerDieByHit()
    {
        hitSound.Play();
        TakeDamage(15);
    }

    //When Player Lose By Falling Down
    public void PlayerDieFalling()
    {
        anim.Play("IdleAnim");
        myPosition.x = 0f;
        transform.position = spawnPosition;
        TakeDamage(15);
    }


    void TakeDamage(int damage)
    {
        if(healthBar != null)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            anim.Play("PlayerTakeDamageAnim");

            if(currentHealth <= 0)
            {
                GameOver();
            }
        }else if(healthBar == null)
        {
            StartCoroutine(Respawn());
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.25f);
        transform.position = spawnPosition;
    }


    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Potato"))
        {
            jump = 18f;
            potato[0].SetActive(false);
        }
    }
*/
}
