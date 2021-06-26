using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Weapon : MonoBehaviour
{

    #region Fire Variables

    public Transform middleFirePoint;
    public Transform downFirePoint;
    public Transform upFirePoint;
        
    public GameObject bulletPrefab;

    public Bullet bullet;

    public float speed;

    #endregion

    #region Video Variables
        
    public VideoPlayer videoPlayer;
    public AudioSource audioSource3;

    #endregion

    public PlayerMovement playerMovement;

    Animator anim;

    void Start()
    {
        StartCoroutine(WaitForShooting());
        anim = GetComponent<Animator>();
    }

    void Shoot()
    {
        if(upFirePoint == null || downFirePoint == null)
        {  
        Instantiate(bulletPrefab, middleFirePoint.position, middleFirePoint.rotation);    
        }
        else
        {
            if(playerMovement.isCrouching)
            {
                Instantiate(bulletPrefab, downFirePoint.position, downFirePoint.rotation);
            }
            else if(playerMovement.isJumping)
            {
                Instantiate(bulletPrefab, upFirePoint.position, upFirePoint.rotation);
            }
            else
            Instantiate(bulletPrefab, middleFirePoint.position, middleFirePoint.rotation);
        }
    }

    IEnumerator WaitForShooting()
    {
        yield return new WaitForSeconds(speed);

        Shoot();
        
        if(videoPlayer != null)
        {
        videoPlayer.Play();
        audioSource3.Play();
        }

        StartCoroutine(WaitForShooting());
    }

}
