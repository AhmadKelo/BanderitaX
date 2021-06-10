using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject canvas;

    public Bullet bullet;

    void Start()
    {
        StartCoroutine(WaitForShooting());

    }

    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator WaitForShooting()
    {
        yield return new WaitForSeconds(2.5f);
        Shoot();
        canvas.SetActive(false);
        canvas.SetActive(true);
        //bullet.speed += 0.025f;
        StartCoroutine(WaitForShooting());
    }
}
