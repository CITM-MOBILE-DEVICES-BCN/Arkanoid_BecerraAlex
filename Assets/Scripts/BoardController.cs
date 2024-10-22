using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoardController 
{
    public List<BrickBehaviour> bricks;
    public int brickCount = 0;
    public bool counted = false;



    public BoardController()
    {
        bricks = new List<BrickBehaviour>();
        CountBricks();
    }
    public void CountBricks()
    {
        GameObject[] brickObjects = GameObject.FindGameObjectsWithTag("Brick");

        // Limpia la lista antes de añadir los nuevos bricks
        bricks.Clear();
        foreach (GameObject obj in brickObjects)
        {
            BrickBehaviour brickBehaviour = obj.GetComponent<BrickBehaviour>();
            if (brickBehaviour != null)
            {
                bricks.Add(brickBehaviour);
            }
        }

        // Cuenta los bricks y actualiza el contador
        brickCount = bricks.Count;
        counted = true;
    }
    

    public void BrickDestroyed()
    {
        brickCount--;
        Debug.Log(brickCount);
        if (brickCount == 0)
        {

           GameManager.instance.LoadVictoryCanvas();
        }


    }
   
}
