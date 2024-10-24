using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public Color OneShot;
    public Color TwoShot;
    public Color ThreeShot;
    public Color FourShotShot;
    public GameObject powerPrefab;
    private List<Color> colorStates = new List<Color>();
    private Color currentColor;
    private Renderer blockRenderer;

    private void Start()
    {
        colorStates.Add(OneShot);
        colorStates.Add(TwoShot);
        colorStates.Add(ThreeShot);
        colorStates.Add(FourShotShot);
       
        blockRenderer = GetComponent<Renderer>();
     
        if (blockRenderer == null)
        {
            return;
        }

        int randomIndex = Random.Range(0, colorStates.Count);
        currentColor = colorStates[randomIndex];
        blockRenderer.material.color = currentColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    { 
        if (blockRenderer == null) return;

        int currentIndex = -1;
        for (int i = 0; i < colorStates.Count; i++)
        {
            if (colorStates[i] == currentColor)
            {
                currentIndex = i;
                break;
            }
        }

        
        if (currentIndex != -1)
        {
            switch (currentIndex)
            {
                case 0: // OneShot
                    gameObject.SetActive(false);
                    GameUI.instance.UpdateScore();
                    GameManager.instance.boardController.BrickDestroyed();
                    int randomNumber = Random.Range(1, 101); 
                    if (randomNumber >= 1 && randomNumber <= 10) // Prefab 10/100
                    {
                        Instantiate(powerPrefab, transform.position, Quaternion.identity); 
                    }
                    break;

                case 1: // TwoShot
                    currentColor = OneShot;
                    blockRenderer.material.color = currentColor;
                    GameUI.instance.UpdateScore();
                    break;

                case 2: // ThreeShot
                    currentColor = TwoShot;
                    blockRenderer.material.color = currentColor;
                    GameUI.instance.UpdateScore();
                    break;

                case 3: // BlueState
                    currentColor = ThreeShot;
                    blockRenderer.material.color = currentColor;
                    GameUI.instance.UpdateScore();
                    break;

                default:
                    currentColor = OneShot;
                    blockRenderer.material.color = currentColor;
                    break;
            }
        }
        else
        {
            currentColor = OneShot;
            blockRenderer.material.color = currentColor;
        }
    }
}

