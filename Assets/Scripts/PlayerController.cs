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
        // Obt�n la posici�n del slider.
        float sliderValue = positionSlider.value;
        // Convierte el valor del slider a la posici�n del mundo.
        float worldPositionX = Mathf.Lerp(-boundary, boundary, sliderValue);

        // Crea un nuevo vector de posici�n usando el valor del slider.
        Vector3 targetPosition = new Vector3(worldPositionX, transform.position.y, transform.position.z);

        // Interpola la posici�n del objeto hacia la nueva posici�n objetivo.
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
        
        
            // Obt�n la posici�n en X de la bola
            float ballPositionX = ball.transform.position.x;

            // Aseg�rate de que el jugador no se salga de los l�mites establecidos
            ballPositionX = Mathf.Clamp(ballPositionX, -boundary, boundary);

            // Actualiza la posici�n del jugador para que siga la posici�n en X de la bola
            Vector3 targetPosition = new Vector3(ballPositionX, transform.position.y, transform.position.z);

            // Interpola la posici�n del jugador hacia la posici�n objetivo para un movimiento suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed + 10 * Time.deltaTime);
            AutoplayEnabled = true;
        
        
    }

    private void DisableAutoPlay()
    {
        AutoplayEnabled = false;
    }
}

