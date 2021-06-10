using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        isJumping = false;
        mySprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawnPosition = transform.position;
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        //Player direction
        if (Input.GetKey(KeyCode.A) && !PauseMenuScript.GameIsPaused)
        {
            mySprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.D) && !PauseMenuScript.GameIsPaused)
        {
            mySprite.flipX = false;
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
    }

    //When Player Lose By Falling Down
    public void PlayerDieFalling()
    {
        //anim.Play("DieAnim");
        anim.Play("IdleAnim");
        myPosition.x = 0f;
        transform.position = spawnPosition;
    }

    //Wait to Respawn
    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = spawnPosition;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Potato"))
        {
            jump = 18f;
            potato[0].SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Stair"))
        {
            
        }
    }

}
