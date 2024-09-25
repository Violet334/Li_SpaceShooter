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

    private void Start()
    {
        acceleration = targetSpeed / accelerationTime;
    }

    void Update()
    {
        //velocity += speed * transform.up * Time.deltaTime;
        PlayerMovement();
        // transform.position += velocity.normalized * speed *Time.deltaTime;
        Debug.Log(speed);
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
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            accelerate = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accelerate = true;
            velocity += speed * Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            accelerate = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            accelerate = true;
            velocity += speed * Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
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


}
