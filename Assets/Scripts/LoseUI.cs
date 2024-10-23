using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    public GameObject loseMenu;

    void Start()
    {
        GameManager.instance.loseUI = this;
        loseMenu.SetActive(false);
    }

    public void LoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToMenu()
    {
        GameManager.instance.gameData.ResetData();
        GameManager.instance.LoadMenu();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
   
}
