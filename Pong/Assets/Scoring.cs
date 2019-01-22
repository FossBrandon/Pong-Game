using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    // Variables we will use
    public static int leftPlayerPoints = 0;
    public static int rightPlayerPoints = 0;

    public GUISkin setup;

    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score(string wall)
    {
        // If right wall is hit, increase point for left player
        if(wall == "WallRight")
        {
            leftPlayerPoints++;
        }

        // If left wall is hit, increase point for right player
        else
        {
            rightPlayerPoints++;
        }
    }

    private void OnGUI()
    {
        GUI.skin = setup;

        GUI.Label(new Rect(Screen.width / 2 - 150, 100, 100, 100), "" + leftPlayerPoints); // Displays left players points
        GUI.Label(new Rect(Screen.width / 2 + 115, 100, 100, 100), "" + rightPlayerPoints); // Displays right players points

        // Creates a button for Restarting the game
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 100, 120, 53), "RESTART"))
        {
            leftPlayerPoints = 0; // Points get reset
            rightPlayerPoints = 0;
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver); // Calls other function to restart game
        }

        // If left player wins, then display winning message
        if(leftPlayerPoints == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "LEFT PLAYER WINS!");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }

        // If right player wins, then display winning message
        else if(rightPlayerPoints == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "Right PLAYER WINS!");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }

    }
}
