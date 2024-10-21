using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField ]private BallController ballController;
    private void Start()
    {
        // Cargar los datos al inicio del juego
        (int score, int numBalls, int best) = GameData.Load();

        // Establecer los valores cargados en el ScoreUI
        //ScoreUI.instance.SetScore(score);
        //ScoreUI.instance.SetBest(best);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Guardar los datos actuales cuando se presiona "W"
            int score = ScoreUI.instance.GetScore();
            int best = ScoreUI.instance.GetBest();
            int numBalls = ballController.GetNumBalls();
            GameData.Save(score, numBalls, best);
            Debug.Log("Datos guardados.");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Cargar los datos cuando se presiona "R"
           
            (int score, int numBalls, int best) = GameData.Load();
            ScoreUI.instance.SetScore(score);
            ScoreUI.instance.SetBest(best);
            ballController.SetNumBalls(numBalls);
            ScoreUI.instance.UpdateLifes();
            Debug.Log($"Datos cargados - Score: {score}, BestScore: {best}");
        }
    }
}
