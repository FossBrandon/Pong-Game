using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Variables for later use
    private Rigidbody2D body;
    [SerializeField] float speed = 50; // Serialize lets me change value within unity
    [SerializeField] float speed2 = 23;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Invoke("BallStart", 2); // Calls the start function with a delay of 2 seconds
    }

    // This will choose whether to start the ball moving left or right
    void BallStart()
    {
        float random = Random.Range(0, 10); // Creates random number between 0 and 10

        // This will start the ball moving right
        if(random > 5)
        {
            body.AddForce(new Vector2(speed, -45));
        }

        // This will start the ball moving left
        else
        {
            body.AddForce(new Vector2(speed * -1, -45));
        }
    }

    // This will reset the ball upon someone scoring a point
    void ResetBall()
    {
        body.velocity = Vector2.zero; // Stops it from moving
        transform.position = Vector2.zero; // Resets it to the center of the board
    }

    // This will reset the ball and restart the game
    void RestartGame()
    {
        ResetBall();
        Invoke("BallStart", 2);
    }

    // This determines where on the paddle the ball hits. Split into three sections
    float hitLocation(Vector2 ballLocation, Vector2 paddleLocation, float paddleHeight)
    {
        return (ballLocation.y - paddleLocation.y) / paddleHeight;
    }

    // This will determine what happens when the ball makes contact with the paddles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PaddleLeft")
        {
            // Calculate hit Factor
            float y = hitLocation(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Calculate direction
            Vector2 dir = new Vector2(1, y).normalized;

            // Set new Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed2;
        }

        // Conditions for right paddle
        if (collision.gameObject.name == "PaddleRight")
        {
            // Calculate hit Factor
            float y = hitLocation(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            // Calculate direction 
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set new Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed2;
        }
    }
}
