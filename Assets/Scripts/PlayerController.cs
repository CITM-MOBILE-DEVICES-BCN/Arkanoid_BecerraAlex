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
        // Obt�n la posici�n del slider.
        float sliderValue = positionSlider.value;

        // Convierte el valor del slider a la posici�n del mundo.
        float worldPositionX = Mathf.Lerp(-boundary, boundary, sliderValue);

        // Crea un nuevo vector de posici�n usando el valor del slider.
        Vector3 targetPosition = new Vector3(worldPositionX, transform.position.y, transform.position.z);

        // Interpola la posici�n del objeto hacia la nueva posici�n objetivo.
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}

