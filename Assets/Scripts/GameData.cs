using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    
    private const string ScoreKey = "Score";
    private const string BestKey = "BestScore";
    private const string NumBallsKey = "NumBalls";
    private const string hasSavedKey = "hasSaved";

    public int numBalls = 3;
    public int score;
    public int best;
    public int hasSaved = 0;




    // Método para guardar el puntaje y el número de bolas
    public void Save()
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
    public void Load()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0); // 0 es el valor por defecto si no hay datos
        best = PlayerPrefs.GetInt(BestKey, 0); // 3 es el valor por defecto
        numBalls = PlayerPrefs.GetInt(NumBallsKey, 3); // 3 es el valor por defecto
        hasSaved = PlayerPrefs.GetInt(hasSavedKey, 0); // 3 es el valor por defecto
        
    }
   
    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        PlayerPrefs.DeleteKey(NumBallsKey);
        //PlayerPrefs.DeleteKey(BestKey);
        PlayerPrefs.DeleteKey(hasSavedKey);
        PlayerPrefs.Save();
    }

   

    public int GetScore()
    {
        return score;
    }

    public int GetBest()
    {
        return best;
    }
    public int GetNumBalls()
    {
        return numBalls;
    }
}

