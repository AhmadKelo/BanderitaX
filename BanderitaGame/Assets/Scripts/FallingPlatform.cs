﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 spawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rb.isKinematic = false;
        Invoke("AfterDrop",2f);
    }

    void AfterDrop()
    {
        transform.position = spawnPosition;
        rb.bodyType = RigidbodyType2D.Static;
    }


}
