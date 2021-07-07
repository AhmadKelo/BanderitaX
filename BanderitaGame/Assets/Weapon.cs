using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Weapon : MonoBehaviour
{

    #region Fire Variables

    public Transform FirePoint;
        
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
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);    

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
