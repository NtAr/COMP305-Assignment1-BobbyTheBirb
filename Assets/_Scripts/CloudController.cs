// ===============================
// AUTHOR:        Nataliia Arsenieva
// CREATE DATE:   September 30, 2019
// PURPOSE:       Control each cloud object.
// SPECIAL NOTES: All attributes are different for some objects. All values added in Unity.
// ===============================
// Change History: -
//
//=================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloud
{
    public class CloudController : MonoBehaviour
    {
        [SerializeField]
        public Boundary boundary;

        [SerializeField]
        public Speed verticalSpeedRange;

        [SerializeField]
        public Speed horizontalSpeedRange;

        public float cloudStartPosition;

        public float verticalSpeed;
        public float horizontalSpeed;

        public float randomXPosition;
        public float randomYPosition;

        public GameObject cloudExplosion; //explosion animation

        // Start is called before the first frame update
        void Start()
        {
            Reset();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            CheckBounds();           
        }
        public void Reset() //resets the cloud at a random point within the boundaries.
        {
            horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max); //randomize speed

            randomYPosition = Random.Range(boundary.TopBounds, boundary.BottomBounds);
            randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds + cloudStartPosition);

            transform.position = new Vector2(randomXPosition, randomYPosition);
        }

        void CheckBounds() //check boundaries
        {
            if (transform.position.x <= -10)
            {
                Reset();
            }
        }
        void Move() //movement implementation
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "Player")
            {
                Instantiate(cloudExplosion, transform.position, transform.rotation); //show explosion animation
                Reset(); //"destroy" cloud by resetting it to the start point
                Destroy(GameObject.FindGameObjectWithTag("cloudExplosion"), 0.5f); //destroy the animation gameObject after 0.5 sec;
            }
        }      
    }
}
