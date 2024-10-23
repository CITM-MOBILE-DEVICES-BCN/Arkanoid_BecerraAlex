using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.winUI = this;
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    

    public void WinMenu()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

   
    public void SaveAndQuit()
    {

        GameManager.instance.gameData.Save();
       
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    public void ContinueButton()
    {
        if (GameManager.instance.gameData.currentScene == "Level1")
        {
            GameManager.instance.gameData.currentScene = "Level2";
            GameManager.instance.gameData.Save();
            SceneManager.LoadScene("Level2");
            GameManager.instance.gameData.Load();
        } else 
        {
            GameManager.instance.gameData.currentScene = "Level1";
            GameManager.instance.gameData.Save();
            GameManager.instance.gameData.Load();
            SceneManager.LoadScene("Level1");

        }
    }
   
}
