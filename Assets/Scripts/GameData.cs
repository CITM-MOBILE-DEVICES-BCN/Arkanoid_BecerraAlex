using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameData 
{
    
    private const string ScoreKey = "Score";
    private const string BestKey = "BestScore";
    private const string NumBallsKey = "NumBalls";
    private const string hasSavedKey = "hasSaved";
    private const string currentSceneKey = "currentScene";

    public int numBalls = 3;
    public int score;
    public int best;
    public int hasSaved = 0;
    public string currentScene;


    public void Save()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.SetInt(NumBallsKey, numBalls);
        PlayerPrefs.SetInt(BestKey, best);
        PlayerPrefs.SetInt(hasSavedKey, 1);
        PlayerPrefs.SetString(currentSceneKey, currentScene);
        PlayerPrefs.Save();
    }
    public int GethasSaved()
    {
        return PlayerPrefs.GetInt(hasSavedKey, 0);
    }

    public void Load()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0);
        best = PlayerPrefs.GetInt(BestKey, 0);
        numBalls = PlayerPrefs.GetInt(NumBallsKey, 3); 
        hasSaved = PlayerPrefs.GetInt(hasSavedKey, 0);
        currentScene = PlayerPrefs.GetString(currentSceneKey, "MainMenu");
    }
    public void LoadBest()
    {
        best = PlayerPrefs.GetInt(BestKey, 0);
    }
    public void ResetData()
    {
        PlayerPrefs.SetInt(ScoreKey, 0);
        PlayerPrefs.SetInt(NumBallsKey, 3);
        PlayerPrefs.SetInt(hasSavedKey, -5);
        PlayerPrefs.SetString(currentSceneKey, "MainMenu");
        PlayerPrefs.SetInt(BestKey, best);
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

