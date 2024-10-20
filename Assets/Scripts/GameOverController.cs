using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private BallController ballController;
    [SerializeField] GameObject ball;

    private void Start()
    {
        ballController = ball.GetComponent<BallController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            
            CheckBallsLeft();
        
        
    }

    private void CheckBallsLeft()
    {
        if (ballController.numBalls > 1f)
        {
            ballController.ResetBall();
            ballController.numBalls = ballController.numBalls - 1f;
        }
    }
}
