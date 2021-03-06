using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    #region Component Variables
    SpriteRenderer mySprite;
    Rigidbody2D rb;
    Animator anim;
    #endregion
    

    #region Speed and Jump Variables
    [Header("Speed and Jump")]
    [SerializeField] float speed = 7f;
    [SerializeField] float jump = 12.5f;
    public bool isJumping = false;
    #endregion
    
    
    #region Vector Variables
      Vector3 spawnPosition;  
      Vector3 myPosition;
    #endregion
    

    #region Sound Variables
    [Header("Sounds")]
    public AudioSource hitSound;
    #endregion


    #region Player Health Variables
    [Header("Player Health")]
    public int maxHealth;
    public int currentHealth;
    public HealthBarScript healthBar;
    public bool lost;
    #endregion



    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawnPosition = transform.position;

        if(healthBar != null)
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {

        #region Player Direction
        if (myPosition.x > 0 && !PauseMenuScript.GameIsPaused)
        {
                transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if (myPosition.x < 0 && !PauseMenuScript.GameIsPaused)
        {
                transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        #endregion

        #region Run Animation
        
        anim.SetFloat("Speed", Mathf.Abs(myPosition.x));

        #endregion

        #region Player Fall Down

        if (transform.position.y < -5f)
        {
            PlayerLoseFalling();
        }
        
        #endregion

        #region Crouch

        // if (Input.GetKey(KeyCode.S) && !isJumping && !PauseMenuScript.GameIsPaused)
        // {
        //     anim.SetBool("isCrouching", true);
        //     speed = 4f;
        //     bc1.enabled = false;
        //     bc2.enabled = true;
        //     isCrouching = true;
        // }
        // else 
        // {
        //     anim.SetBool("isCrouching", false);
        //     speed = 7f;
        //     bc1.enabled = true;
        //     bc2.enabled = false;
        //     isCrouching = false;
        // }

        #endregion

        #region Jump

        if (Input.GetKeyDown(KeyCode.W) && !isJumping && !PauseMenuScript.GameIsPaused && !lost)
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

        #endregion

    }


    private void FixedUpdate()
    {
        #region Movement

        if(!lost)
        {

        myPosition.x = Input.GetAxisRaw("Horizontal");
        transform.position += myPosition * speed * Time.fixedDeltaTime;

        }

        #endregion
    }



    #region Player Lose and Take Damage

    //When Player Take Damage by Controller Hit
    public void PlayerHit()
    {
        hitSound.Play();
        TakeDamage(15);
    }

    //When Player Lose by Falling
    public void PlayerLoseFalling()
    {
        transform.position = spawnPosition;
        if(healthBar != null)
        TakeDamage(15);
    }


    void TakeDamage(int damage)
    {
        if(healthBar != null)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);


            if(currentHealth <= 0)
            {
                anim.Play("Player Loose");  
                lost = true;

                StartCoroutine(GameOver());
            }else
            {
                anim.Play("Player Hurt");
            }
        }
        else if(healthBar == null)
        {
            anim.Play("Player Loose"); 
            lost = true;
            StartCoroutine(Respawn());

            rb.velocity = new Vector2(0,-1f);
        }

    }

    #endregion

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);
        lost = false;
        anim.Play("PlayerIdle");
        transform.position = spawnPosition;
    }

}
