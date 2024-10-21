using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private TextMeshProUGUI lifesText;
    public int numBalls = 3;
    public static ScoreUI instance;
    private int score;
    private int best;
    private BallController ballController;
    [SerializeField] GameObject ball;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        scoreText.text = score.ToString();
        bestText.text = best.ToString();
        ballController = ball.GetComponent<BallController>();
        lifesText.text = numBalls.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        UpdateBest();
    }
    public void UpdateLifes()
    {
        lifesText.text = numBalls.ToString();
    }
    public void UpdateBest()
    {
        if (score>best)
        {
            best = score;
        }
        bestText.text = best.ToString();
    }
    public int GetScore()
    {
        return score;
    }

    public int GetBest()
    {
        return best;
    }
    public void SetScore(int value)
    {
        score = value;
        scoreText.text = score.ToString();
    }

    public void SetBest(int value)
    {
        best = value;
        bestText.text = best.ToString();
    }
    public void SetNumBalls(int value)
    {
        numBalls = value;
    }

    // Método para obtener el número de bolas
    public int GetNumBalls()
    {
        return numBalls;
    }
}
