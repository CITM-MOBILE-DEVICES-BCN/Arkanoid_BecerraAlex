using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private BallController ballController;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject UI;

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
        if (ScoreUI.instance.numBalls > 1f)
        {
            ballController.ResetBall();
            ScoreUI.instance.numBalls = ScoreUI.instance.numBalls - 1;
            ScoreUI.instance.UpdateLifes();
        }
    }
}
