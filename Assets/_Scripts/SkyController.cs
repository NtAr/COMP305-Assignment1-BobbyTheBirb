// ===============================
// AUTHOR:        Nataliia Arsenieva
// CREATE DATE:   September 30, 2019
// PURPOSE:       Set up the boundaries for different objects.
// SPECIAL NOTES: All attributes are different for some objects. All values added in Unity.
// ===============================
// Change History: -
//
//=================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public bool sky_copy;
    private float startPosition = 24f;
    private float m_rightResetPosition = 24.5f;
    private float m_leftResetPosition = -23f;

    // Start is called before the first frame update
    void Start()
    {
        //set the start position of each sprite
        if (sky_copy == true)
        {
            transform.position = new Vector2(startPosition, 0.0f);
        } else
        {
            transform.position = new Vector2(0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void Reset()
    {
        transform.position = new Vector2(m_rightResetPosition, 0.0f);

    }
    void CheckBounds()
    {
        if (transform.position.x <= m_leftResetPosition)
        {
            Reset();
        }
    }
    
}
