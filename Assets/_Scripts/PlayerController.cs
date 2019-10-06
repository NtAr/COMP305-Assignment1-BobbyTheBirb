using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;
    public GameController gameController;

    public Transform bullet;
    public GameObject bulletImg;
    public GameObject lives;

    private float time = 0.5f;

    //public Camera camera;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Move()
    {
        Vector2 currentPositiion = transform.position;
        if (Input.GetAxis("Vertical") > 0)
            currentPositiion += new Vector2(0.0f, speed.max);

        if (Input.GetAxis("Vertical") < 0)
        {
            currentPositiion += new Vector2(0.0f, speed.min);
        }

        transform.position = currentPositiion;
    }

    public void CheckBounds()
    {
        if (transform.position.y >= boundary.TopBounds)
        {
            transform.position = new Vector2(transform.position.x, boundary.TopBounds);
            //gameController.Lives -= 1;
        }

        if (transform.position.y <= boundary.BottomBounds)
        {
            transform.position = new Vector2(transform.position.x, boundary.BottomBounds);
            //gameController.Lives -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cloud" || collision.gameObject.tag == "border"
            || collision.gameObject.tag == "evil_bullet")
        {
            Instantiate(lives, transform.position, transform.rotation);
            gameController.Lives -= 1;
            
            
        }
    }

    
    
        
    public void Shoot()
    {
        Instantiate(bulletImg, bullet.position, bullet.rotation);
    }
}
