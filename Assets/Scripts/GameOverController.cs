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

        if (collision.gameObject.CompareTag("ball") && ballController.ballsInGame == 1)
        {
            CheckBallsLeft();
        }
        else
        {
            collision.gameObject.SetActive(false);
            if (collision.gameObject.CompareTag("ball"))
            {
                ballController.ballsInGame = ballController.ballsInGame - 1;
            }
           
        }
          
        
        
    }

    private void CheckBallsLeft()
    {
        if (GameManager.instance.gameData.numBalls > 1f)
        {
            ball.SetActive(true);
            ballController.ResetBall();
            GameManager.instance.gameData.numBalls = GameManager.instance.gameData.numBalls - 1;
            GameUI.instance.UpdateLifes();
        }
    }
}
