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
        bricks.Clear();
        foreach (GameObject obj in brickObjects)
        {
            BrickBehaviour brickBehaviour = obj.GetComponent<BrickBehaviour>();
            if (brickBehaviour != null)
            {
                bricks.Add(brickBehaviour);
            }
        }

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
