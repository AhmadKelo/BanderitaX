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
    [Space(20)]
    #endregion
    

    #region Vector Variables
      Vector3 spawnPosition;  
      Vector3 myPosition;
    #endregion
    

    #region Sound Variables
    [Header("Sounds")]
    public AudioSource hitSound;
    #endregion


    #region Crouch Variables
    [Header("Crouch")]
    public BoxCollider2D bc1;
    public BoxCollider2D bc2;
    public bool isCrouching;
    
    #endregion


    #region Player Health Variables
    [Header("Player Health")]
    public int maxHealth;
    public int currentHealth;
    public HealthBarScript healthBar;
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
            PlayerDieFalling();
        }
        
        #endregion

        #region Crouch

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

        #endregion


        #region Jump

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

        #endregion

    }


    private void FixedUpdate()
    {
        #region Movement

        myPosition.x = Input.GetAxisRaw("Horizontal");
        transform.position += myPosition * speed * Time.fixedDeltaTime;

        #endregion
    }



    #region Player Loose and Take Damage

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
        if(healthBar != null)
        TakeDamage(15);
        else if(healthBar == null)
        Respawn();
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

    #endregion

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.25f);
        transform.position = spawnPosition;
    }

}
