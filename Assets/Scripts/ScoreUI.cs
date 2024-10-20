using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestText;
    public static ScoreUI instance;
    private int score;
    private int best;

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
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        UpdateBest();
    }

    public void UpdateBest()
    {
        if (score>best)
        {
            best = score;
        }
        bestText.text = best.ToString();
    }
}
