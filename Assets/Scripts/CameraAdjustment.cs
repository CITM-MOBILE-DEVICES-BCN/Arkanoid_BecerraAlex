using UnityEngine;

public class CameraAdjustment : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        AdjustScaleAndPosition();
    }

    void AdjustScaleAndPosition()
    {
        // Obtener el centro de la cámara en el eje Z = 0
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);

        // Convertir las esquinas del Viewport a puntos en el mundo
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(Vector3.zero);
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Calcular el tamaño de la pantalla en unidades del mundo
        Vector3 screenSize = topRight - bottomLeft;
        float screenRatio = screenSize.x / screenSize.y;
        float desiredRatio = transform.localScale.x / transform.localScale.y;

        // Ajustar la escala del objeto para que ocupe toda la pantalla sin distorsionarse
        if (screenRatio > desiredRatio)
        {
            float height = screenSize.y;
            transform.localScale = new Vector3(height * desiredRatio, height, 1);
        }
        else
        {
            float width = screenSize.x;
            transform.localScale = new Vector3(width, width / desiredRatio, 1);
        }

        // Asegurarse de que el objeto esté centrado en la pantalla
        Vector3 newPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -mainCamera.transform.position.z));
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

    void Update()
    {
        // Si la resolución de la pantalla cambia durante el juego, actualizar la escala y posición
        AdjustScaleAndPosition();
    }
}

