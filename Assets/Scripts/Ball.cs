using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField ]private Vector2 initialVelocity;
    [SerializeField ]private Transform parentTransform;

    private Rigidbody2D rb;
    private bool isMoving = false;
    public int numBalls = 3;
    [SerializeField] private float speedMult;
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

    public void ResetBall()
    {     
        transform.SetParent(parentTransform); 
        rb.velocity = Vector2.zero; 
        transform.localPosition = Vector3.zero; 
        isMoving = false; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            rb.velocity *= speedMult;
        }
    }
    public void SetNumBalls(int value)
    {
        numBalls = value;
    }

    // Método para obtener el número de bolas
    public int GetNumBalls()
    {
        return numBalls;
    }
}
