using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Variables that will be manipulated to control the paddles
    [SerializeField] float speed = 10.0f; // Serialize lets me alter values within unity
    [SerializeField] float topBoundary = 4.0f;
    [SerializeField] float bottomBoundary = -4.0f;
    [SerializeField] KeyCode up = KeyCode.W;
    [SerializeField] KeyCode down = KeyCode.S;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = body.velocity; // Creating a velocity variable

        // If input is W, then move paddle up with given speed
        if(Input.GetKey(up))
        {
            velocity.y = speed; 
        }

        // Else if input is S, then move paddle down with specified speed
        else if(Input.GetKey(down))
        {
            velocity.y = -speed;
        }

        // If no input, don't move up or down
        else
        {
            velocity.y = 0;
        }

        body.velocity = velocity;

        Vector3 position = transform.position;

        // If it tries to go above top boundary, stop it
        if(position.y > topBoundary)
        {
            position.y = topBoundary;
        }

        // If it tires to go below bottom boundary, stop it
        if(position.y < bottomBoundary)
        {
            position.y = bottomBoundary;
        }

        transform.position = position;
    }
}
