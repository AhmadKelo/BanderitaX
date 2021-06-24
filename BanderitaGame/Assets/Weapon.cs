using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform middleFirePoint;
    public Transform downFirePoint;
    public Transform upFirePoint;

    public GameObject bulletPrefab;

    public GameObject canvas;

    public Bullet bullet;

    public float speed;

    public PlayerMovement playerMovement;

    Animator anim;
    void Start()
    {
        StartCoroutine(WaitForShooting());
        anim = GetComponent<Animator>();
    }

    void Update()
    {

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
        if(canvas != null)
        {
        canvas.SetActive(false);
        canvas.SetActive(true);
        }

        StartCoroutine(WaitForShooting());
    }

}
