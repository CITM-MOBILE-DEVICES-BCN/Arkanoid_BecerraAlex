using UnityEngine;

public class GameData 
{
    private const string ScoreKey = "Score";
    private const string BestKey = "BestScore";
    private const string NumBallsKey = "NumBalls";

    // Método para guardar el puntaje y el número de bolas
    public static void Save(int score, int numBalls, int best)
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.SetInt(NumBallsKey, numBalls);
        PlayerPrefs.SetInt(BestKey, best);
        PlayerPrefs.Save(); // Asegúrate de guardar los cambios
    }

    // Método para cargar el puntaje y el número de bolas
    public static (int , int , int ) Load()
    {
        int score = PlayerPrefs.GetInt(ScoreKey, 0); // 0 es el valor por defecto si no hay datos
        int best = PlayerPrefs.GetInt(BestKey, 0); // 3 es el valor por defecto
        int numBalls = PlayerPrefs.GetInt(NumBallsKey, 3); // 3 es el valor por defecto
        return (score, numBalls, best);
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        PlayerPrefs.DeleteKey(NumBallsKey);
        PlayerPrefs.DeleteKey(BestKey);
        PlayerPrefs.Save();
    }
}

