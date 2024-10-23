using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;  
    public float boundary = 3.7f;
    public Slider positionSlider; // Referencia al slider.
    private bool AutoplayEnabled = false;
    [SerializeField] GameObject ball;
    private BallController ballController;


    void Start()
    {
        Time.timeScale = 1;
        ballController = ball.GetComponent<BallController>();

    }

    void Update()
    {
        // Obtén la posición del slider.
        float sliderValue = positionSlider.value;
        // Convierte el valor del slider a la posición del mundo.
        float worldPositionX = Mathf.Lerp(-boundary, boundary, sliderValue);

        // Crea un nuevo vector de posición usando el valor del slider.
        Vector3 targetPosition = new Vector3(worldPositionX, transform.position.y, transform.position.z);

        // Interpola la posición del objeto hacia la nueva posición objetivo.
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A) || AutoplayEnabled == true)
        {
            AutoPlay();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DisableAutoPlay();
        }
       
       
    }

    private void AutoPlay()
    {
        
        
            // Obtén la posición en X de la bola
            float ballPositionX = ball.transform.position.x;

            // Asegúrate de que el jugador no se salga de los límites establecidos
            ballPositionX = Mathf.Clamp(ballPositionX, -boundary, boundary);

            // Actualiza la posición del jugador para que siga la posición en X de la bola
            Vector3 targetPosition = new Vector3(ballPositionX, transform.position.y, transform.position.z);

            // Interpola la posición del jugador hacia la posición objetivo para un movimiento suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed + 10 * Time.deltaTime);
            AutoplayEnabled = true;
        
        
    }

    private void DisableAutoPlay()
    {
        AutoplayEnabled = false;
    }
}

