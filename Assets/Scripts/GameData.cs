using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    
    private const string ScoreKey = "Score";
    private const string BestKey = "BestScore";
    private const string NumBallsKey = "NumBalls";
    private const string hasSavedKey = "hasSaved";



   
    // Método para guardar el puntaje y el número de bolas
    public void Save(int score, int numBalls, int best,int hasSaved)
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.SetInt(NumBallsKey, numBalls);
        PlayerPrefs.SetInt(BestKey, best);
        PlayerPrefs.SetInt(hasSavedKey, 1);
        PlayerPrefs.Save(); // Asegúrate de guardar los cambios
        
    }
    public int GethasSaved()
    {
        return PlayerPrefs.GetInt(hasSavedKey, 0);
    }
    // Método para cargar el puntaje y el número de bolas
    private static (int , int , int, int) LoadDataFromPlayerRefs()
    {
        int score = PlayerPrefs.GetInt(ScoreKey, 0); // 0 es el valor por defecto si no hay datos
        int best = PlayerPrefs.GetInt(BestKey, 0); // 3 es el valor por defecto
        int numBalls = PlayerPrefs.GetInt(NumBallsKey, 3); // 3 es el valor por defecto
        int hasSaved = PlayerPrefs.GetInt(hasSavedKey, 0); // 3 es el valor por defecto
        return (score, numBalls, best, hasSaved);
    }
    public void Load()
    {
        (int score, int numBalls, int best, int hasSaved) =LoadDataFromPlayerRefs();
        ScoreUI.instance.SetScore(score);
        ScoreUI.instance.SetBest(best);
        ScoreUI.instance.SetNumBalls(numBalls);
        ScoreUI.instance.UpdateLifes();
        Debug.Log($"Datos cargados - Score: {score}, BestScore: {best}");
    }
    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        PlayerPrefs.DeleteKey(NumBallsKey);
        PlayerPrefs.DeleteKey(BestKey);
        PlayerPrefs.DeleteKey(hasSavedKey);
        PlayerPrefs.Save();
    }


}

