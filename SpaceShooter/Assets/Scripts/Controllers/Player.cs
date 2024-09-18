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

    //The amount of time it will take to reach the target speed
    private float timeToReachSpeed = 3f;
    //The speed that we want the character to reach after a certain amount of time
    private float targetSpeed = 2f;

    private float acceleration;

    public float maxSpeed;
    private float accelerationTime = 3f;

    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
    }

    void Update()
    {
        //velocity += speed * transform.up * Time.deltaTime;
        transform.position += velocity.normalized * speed *Time.deltaTime;
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * Vector3.up * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += acceleration * Vector3.down * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += acceleration * Vector3.left * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * Vector3.right * Time.deltaTime;
        }
        
        
    }


}
