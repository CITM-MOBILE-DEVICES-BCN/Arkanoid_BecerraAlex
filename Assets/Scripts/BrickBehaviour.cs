using UnityEngine;
using System.Collections.Generic;

public class BlockChangeColor : MonoBehaviour
{
    private Color WhiteState = Color.white;
    private Color YellowState = Color.yellow;
    private Color RedState = Color.red;
    private Color GreenState = Color.green;


    private List<Color> colorStates = new List<Color>();

    private Color currentColor;

    private Renderer blockRenderer;

    private void Start()
    {
        colorStates.Add(WhiteState);
        colorStates.Add(YellowState);
        colorStates.Add(RedState);
        colorStates.Add(GreenState);
       

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

    private void ChangeColor()
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
                case 0: // WhiteState
                    gameObject.SetActive(false); 
                    break;

                case 1: // YellowState
                    currentColor = WhiteState;
                    blockRenderer.material.color = currentColor;
                    break;

                case 2: // RedState
                    currentColor = YellowState;
                    blockRenderer.material.color = currentColor;
                    break;

                case 3: // BlueState
                    currentColor = RedState;
                    blockRenderer.material.color = currentColor;
                    break;

                default:
                    currentColor = WhiteState;
                    blockRenderer.material.color = currentColor;
                    break;
            }
        }
        else
        {
            currentColor = WhiteState;
            blockRenderer.material.color = currentColor;
        }
    }
}
