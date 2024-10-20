using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importa esta biblioteca para acceder a UI elements.

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;  
    public float boundary = 7.5f;
    public Slider positionSlider; // Referencia al slider.

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
    }
}

