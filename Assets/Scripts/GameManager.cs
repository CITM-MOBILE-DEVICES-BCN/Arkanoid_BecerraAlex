using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameData gameData;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameData = new GameData();
       
        // Cargar los datos al inicio del juego
     

    
    }
    
    private void Update()
    {
       
    }
}
