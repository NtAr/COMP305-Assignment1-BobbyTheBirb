﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb2d;
    public GameObject explosion;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cloud" || collision.gameObject.tag == "evil_bullet")
        {
            Instantiate(score, transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("explosion"), 0.5f);
        }
    }

    void Update()
    {
        if (transform.position.x >= 8)
        {
            Destroy(gameObject);
        }   
    }




}
