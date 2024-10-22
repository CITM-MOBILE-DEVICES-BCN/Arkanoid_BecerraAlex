using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ContinueButton;
    [SerializeField] GameObject menuCanvas;
    public GameData gameData;
    public WinUI winUI;
    public BoardController boardController;
    public static GameManager instance;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gameData = new GameData();
            boardController = new BoardController();
            DontDestroyOnLoad(this);
            gameData.currentScene = "MainMenu";
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    private void Start()
    {
        // Cargar los datos al inicio del juego
        SceneManager.sceneLoaded += OnSceneLoaded;
        CanContinue();

    }
    private void Update()
    {
        AutoWin();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verificar si se ha cargado el nivel 1 y contar los bricks
        if (scene.name == "Level1" || scene.name == "Level2")
        {
            boardController.CountBricks();
        }
    }
    public void LoadLevel1()
    {

        gameData.currentScene = "Level1";
        SceneManager.LoadScene("Level1");

    }
    public void CanContinue()
    {

        if (gameData.GethasSaved() == 1)
        {
            ContinueButton.SetActive(true);
        }
        else
        {
            ContinueButton.SetActive(false);
        }
    }
    
    public void LoadVictoryCanvas()
    {
       
            winUI.WinMenu();
        
       
    }
    public void AutoWin()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
           
            winUI.winMenu.SetActive(true);
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   public void LoadScene()
    {
        switch (gameData.currentScene)
        {
            case "MainMenu":
                break;
            case "Level1":
                
                gameData.currentScene = "Level1";
                SceneManager.LoadScene("Level1");
                break;
            case "Level2":
               
                gameData.currentScene = "Level2";
                SceneManager.LoadScene("Level2");
                break;

            default:
                break;
        }
    }
    public void LoadData()
    {
        gameData.Load();
        LoadScene();
        
    }

}
