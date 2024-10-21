using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private TextMeshProUGUI lifesText;
    public static GameUI instance;
    private BallController ballController;
    [SerializeField] GameObject ball;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = GameManager.instance.gameData.score.ToString();
        bestText.text = GameManager.instance.gameData.best.ToString();
        ballController = ball.GetComponent<BallController>();
        lifesText.text = GameManager.instance.gameData.numBalls.ToString();
    }

    public void UpdateScore()
    {
        GameManager.instance.gameData.score++;
        scoreText.text = GameManager.instance.gameData.score.ToString();
        UpdateBest();
    }
    public void UpdateLifes()
    {
        lifesText.text = GameManager.instance.gameData.numBalls.ToString();
    }
    public void UpdateBest()
    {
        if (GameManager.instance.gameData.score > GameManager.instance.gameData.best)
        {
            GameManager.instance.gameData.best = GameManager.instance.gameData.score;
        }
        bestText.text = GameManager.instance.gameData.GetBest().ToString();
    }
    
    public void SetScore(int value)
    {
        GameManager.instance.gameData.score = value;
        scoreText.text = GameManager.instance.gameData.GetScore().ToString();
    }

    public void SetBest(int value)
    {
        GameManager.instance.gameData.best = value;
        bestText.text = GameManager.instance.gameData.best.ToString();
    }
    public void SetNumBalls(int value)
    {
        GameManager.instance.gameData.numBalls = value;
    }

    // Método para obtener el número de bolas
   
}
