using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField ]private Vector2 initialVelocity;
    [SerializeField ]private Transform parentTransform;

    private Rigidbody2D rb;
    private bool isMoving = false;
    public int ballsInGame = 1;
    private const float maxSpeed = 10f;


    [SerializeField] private float speedMult;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("EjectBall", 2f);
    }

    void EjectBall()
    {
        if ( !isMoving)
        {
            transform.parent = null;
            isMoving = true;
            rb.velocity = initialVelocity;
        }
    }

    public void ResetBall()
    {     
        transform.SetParent(parentTransform); 
        rb.velocity = Vector2.zero; 
        transform.localPosition = Vector3.zero; 
        isMoving = false;
        ballsInGame = 1;
        Invoke("EjectBall", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity *= speedMult;
            Debug.Log(rb.velocity.magnitude);
        }
        GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.collide);
    }
   
}
