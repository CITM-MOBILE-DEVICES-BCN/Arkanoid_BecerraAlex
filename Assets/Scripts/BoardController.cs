using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public List<BrickBehaviour> bricks;
    
    // Start is called before the first frame update
    void Start()
    {
        var r = Random.Range(0, bricks.Count);
        bricks[r].hasPowerUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
