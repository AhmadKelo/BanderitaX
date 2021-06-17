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
    [SerializeField] Vector3 verticalPosition;

    bool isJumping;

    // Spawning
    Vector3 spawnPosition;

    // Audio
    public AudioSource hitSound;

    // Collider
    BoxCollider2D bc;

    // Potato
    public GameObject[] potato;

    public int maxHealth;
    public int currentHealth;

    public HealthBarScript healthBar;
    void Start()
    {

        //data_stream.Open();

        isJumping = false;
        mySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawnPosition = transform.position;
        bc = GetComponent<BoxCollider2D>();

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
            //bc.enabled = false;

        }
        else
        {
            anim.SetBool("isCrouching", false);
            speed = 7f;
            //bc.enabled = true;

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
        //anim.Play("DieAnim");
        hitSound.Play();
        StartCoroutine(WaitForDie());
        TakeDamage(20);
    }

    //When Player Lose By Falling Down
    public void PlayerDieFalling()
    {
        //anim.Play("DieAnim");
        anim.Play("IdleAnim");
        myPosition.x = 0f;
        transform.position = spawnPosition;
        TakeDamage(20);
    }

    //Wait to Respawn
    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(0.2f);
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
    private void OnTriggerExit2D(Collider2D other)
    {

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
