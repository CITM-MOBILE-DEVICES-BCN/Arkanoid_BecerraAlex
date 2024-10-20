using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField ]private Vector2 initialVelocity;

    private Rigidbody2D rb;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void EjectBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {

            transform.parent = null;
            isMoving = true;
            rb.velocity = initialVelocity;


        }
    }
    // Update is called once per frame
    void Update()
    {
        EjectBall();
    }
}
