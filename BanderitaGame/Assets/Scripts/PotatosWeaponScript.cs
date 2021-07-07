using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatosWeaponScript : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public bool canShoot = true;

    public float shootingDelay;

    PlayerMovement playerMovement;

    Animator anim;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !PauseMenuScript.GameIsPaused && canShoot && !playerMovement.lost)
        {
            anim.SetBool("IsThrowing", true);
            canShoot = false;
            StartCoroutine(ShootingDelay());
        }
    }
    
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        Shoot();

        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
        anim.SetBool("IsThrowing", false);


    }
}
