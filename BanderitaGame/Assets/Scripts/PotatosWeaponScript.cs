using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatosWeaponScript : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    bool canShoot = true;

    public float shootingDelay;
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !PauseMenuScript.GameIsPaused && canShoot)
        {
            canShoot = false;
            Shoot();
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
        canShoot = true;
    }
}
