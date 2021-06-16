using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject canvas;

    public Bullet bullet;

    public float speed;

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
        yield return new WaitForSeconds(speed);
        Shoot();
        if(canvas != null)
        {
        canvas.SetActive(false);
        canvas.SetActive(true);
        }
        //bullet.speed += 0.025f;
        StartCoroutine(WaitForShooting());
    }
}
