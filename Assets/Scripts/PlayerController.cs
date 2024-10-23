using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public Transform boundary;
    public Slider positionSlider;
    private bool AutoplayEnabled = false;
    [SerializeField] GameObject ball;



    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        float sliderValue = positionSlider.value;
        float worldPositionX = Mathf.Lerp(boundary.position.x, -boundary.position.x, sliderValue);
        Vector3 targetPosition = new Vector3(worldPositionX, transform.position.y, transform.position.z);
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
            float ballPositionX = ball.transform.position.x;
            ballPositionX = Mathf.Clamp(ballPositionX, boundary.position.x, -boundary.position.x);
            Vector3 targetPosition = new Vector3(ballPositionX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed + 10 * Time.deltaTime);
            AutoplayEnabled = true;  
    }

    private void DisableAutoPlay()
    {
        AutoplayEnabled = false;
    }
}

