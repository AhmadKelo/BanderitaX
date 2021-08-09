using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Weapon     : MonoBehaviour
{

    #region Fire Variables

    public Transform FirePoint;
        
    public GameObject bulletPrefab;

    public Bullet bullet;

    public float speed;

    #endregion

    #region Video Variables
        
    PlayVideo playVideo;

    public bool hasVideo;

    #endregion
    
    void Start()
    {
        StartCoroutine(WaitForShooting());

        if(hasVideo)
        playVideo = GetComponent<PlayVideo>();
    }

    public void Shoot()
    { 
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);    
    }      

    IEnumerator WaitForShooting()
    {
        yield return new WaitForSeconds(speed);

        Shoot();

        if(hasVideo)
        {
            playVideo.PlayVideoAndAudio();
        }

        StartCoroutine(WaitForShooting());
    }

}
