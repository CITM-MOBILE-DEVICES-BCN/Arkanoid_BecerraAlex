using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuChanger : MonoBehaviour
{
    [SerializeField] GameObject ContinueButton;

    // Método para cargar la escena con el índice especificado
    private void Start()
    {
        CanContinue();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    public void CanContinue()
    {

        if (GameManager.instance.gameData.GethasSaved() == 1)
        {
            ContinueButton.SetActive(true);
        }
        else
        {
            ContinueButton.SetActive(false);
        }
    }

    public void LoadData()
    {
        GameManager.instance.gameData.Load();
        LoadScene();
    }

}
