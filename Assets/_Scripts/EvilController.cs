using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary;

    [SerializeField]
    public Speed verticalSpeedRange;

    [SerializeField]
    public Speed horizontalSpeedRange;

    public float birbStartPosition;

    private float verticalSpeed;
    private float horizontalSpeed;

    private float randomXPosition;
    private float randomYPosition;

    //public GameObject bolt;
 

    //public GameObject birbExplosion;

    //protected internal bool collisionHappened = true;


    // Start is called before the first frame update
    void Start()

    {
        //var time = Random.Range(1f, 3f);
        //InvokeRepeating("Shoot", 2, time);
        //Shoot();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        CheckBounds();
    }

    public void Reset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        randomYPosition = Random.Range(boundary.TopBounds, boundary.BottomBounds);
        randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds + birbStartPosition);
        transform.position = new Vector2(randomXPosition, randomYPosition);
    }
    void CheckBounds()
    {
        if (transform.position.x <= -10)
        {
            Reset();
        }
    }
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    //void Shoot()
    //{
    //    Instantiate(bolt, transform.position, transform.rotation);
    //    //Destroy(GameObject.FindGameObjectWithTag("evil_bullet"), 0.5f);
    //}


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Player")
        {
            //Instantiate(birbExplosion, transform.position, transform.rotation);
            Reset();
        }
    }
}

