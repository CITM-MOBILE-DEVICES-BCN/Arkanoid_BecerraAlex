using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject clone;
    private GameObject ball;
    private BallController ballController;


    void Start()
    {
        ballController = FindAnyObjectByType<BallController>();
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.audioManager.PlaySFX(GameManager.instance.audioManager.powerUp);
            ballController.ballsInGame = ballController.ballsInGame + 1;
            DuplicateObject();
            gameObject.SetActive(false);
        }
    }

    public void DuplicateObject()
    {
        if (ball != null)
        {
            // Crear una nueva posición un poco desplazada del objeto original
            Vector3 newPosition = ball.transform.position; // Desplazar 1 unidad a la derecha

            // Crear el duplicado en la nueva posición
            clone = Instantiate(ball, newPosition, ball.transform.rotation);
            Rigidbody2D originalRigidbody = ball.GetComponent<Rigidbody2D>();
            if (originalRigidbody != null)
            {
                int r = Random.Range(-1, 1);
                // Mantener la dirección de la velocidad original pero ajustar la posición en x
                Vector2 originalVelocity = new Vector2(r * originalRigidbody.velocity.x, originalRigidbody.velocity.y);
               
                // Ajustar la velocidad en el eje x según sea necesario, por ejemplo, cambiar a -1.0 para mover en la dirección opuesta
                originalVelocity.x = Mathf.Sign(originalVelocity.x) * Mathf.Abs(originalVelocity.x); // Mantener la dirección de la velocidad

                // Asignar la misma velocidad de dirección al clon, pero cambiar solo la posición en x
                clone.GetComponent<Rigidbody2D>().velocity = originalVelocity;
            }


        }
        else
        {
            Debug.LogWarning("No se ha asignado un objeto para duplicar.");
        }
    }

}
