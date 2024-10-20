using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;  
    public float boundary = 7.5f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        targetPosition.x = Mathf.Clamp(targetPosition.x, -boundary, boundary);

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
