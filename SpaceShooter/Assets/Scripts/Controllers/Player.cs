using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //private Vector3 velocity = Vector3.right * 0.001f;
    //private float velocity = 0.01f;
    private Vector3 velocity = Vector3.zero;
    private float speed = 0.01f;

    //The speed that we want the character to reach after a certain amount of time
    private float targetSpeed = 2f;

    private float acceleration;

    public float maxSpeed;
    private float accelerationTime = 3f;
    private bool accelerate;

    //deceleration
    public float decelerationTime;
    float deceleration = 2;

    //Week4 Task1
    public float rad;
    public int points;
    //Task2
    public float rad2;
    public int points2;
    public GameObject powerup;

    private void Start()
    {
        acceleration = targetSpeed / accelerationTime;
        deceleration = targetSpeed / decelerationTime;
    }

    void Update()
    {
        //velocity += speed * transform.up * Time.deltaTime;
        PlayerMovement();
        // transform.position += velocity.normalized * speed *Time.deltaTime;
        //Debug.Log(speed);

        //Week4 Task1
        EnemyRadar(rad, points);
        SpawnPowerups(rad2, points2);
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            accelerate = true;
            velocity += speed * Vector3.up * Time.deltaTime;
        }else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            accelerate = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            accelerate = true;
            velocity += speed * Vector3.down * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            accelerate = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accelerate = true;
            velocity += speed * Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            accelerate = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            accelerate = true;
            velocity += speed * Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            accelerate = false;
        }
        if (accelerate == true)
        {
            speed += acceleration * Time.deltaTime;
            transform.position += velocity.normalized * speed * Time.deltaTime;
        }
        else
        {
            speed -= acceleration * Time.deltaTime;
            if (speed < 0)
            {
                speed = 0;
            }
        }
        
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        
        
    }

    //Week4 Task1
    public void EnemyRadar(float radius, int circlePoints)
    { 
        Color radarColor = Color.green;
        if (Vector3.Distance(enemyTransform.position, transform.position) <= radius)
        {
            radarColor = Color.red;
        }

        List<float> angles = new List<float>();
        float angleVal = 360 / circlePoints;
        for(int i = 0; i <= circlePoints; i++)
        {
            float angleInc = angleVal * i;
            angles.Add(angleInc);
        }
        for (int j = 0; j < angles.Count - 1; j++)
        {
            Vector3 startPoint = new Vector3(Mathf.Cos(angles[j] * Mathf.Deg2Rad), Mathf.Sin(angles[j] * Mathf.Deg2Rad)) * radius + transform.position;
            Vector3 endPoint = new Vector3(Mathf.Cos(angles[j + 1] * Mathf.Deg2Rad), Mathf.Sin(angles[j + 1] * Mathf.Deg2Rad)) * radius + transform.position;
            Debug.DrawLine(startPoint, endPoint, radarColor);
        }

    }
    //Task2
    void SpawnPowerups(float radius, int numberOfPowerups)
    {
        List<float> points = new List<float>();
        float angles = 360 / numberOfPowerups;
        for(int i = 0; i <= numberOfPowerups; i++)
        {
            float angleInc = angles * i;
            points.Add(angleInc);
        }
        for(int j = 0; j < points.Count; j++)
        {
            Vector3 spawn = new Vector3(Mathf.Cos(points[j] * Mathf.Deg2Rad), Mathf.Sin(points[j] * Mathf.Deg2Rad)) * radius + transform.position;
            Instantiate(powerup, spawn, Quaternion.identity);
        }
    }
}
