using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player;
    public float radius;

    public float timer = 0;
    Vector3 velocity = Vector3.zero;
    float speed = 0.01f;
    float targetSpeed = 2f;
    float acceleration;
    float accelerationTime = 3f;
    float directionalTimer = 0;
    bool rightDir = true;
    // Start is called before the first frame update
    void Start()
    {
        acceleration = targetSpeed / accelerationTime;
        FindObjectOfType<Player>();

        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 12)
        {
            Destroy(gameObject);
        }

        directionalTimer += Time.deltaTime;
        if(directionalTimer >= 3)
        {
            rightDir = !rightDir;
        }
        if (rightDir)
        {
            velocity += speed * Vector3.right * Time.deltaTime;
        }
        if (!rightDir) 
        {
            velocity += speed * Vector3.left * Time.deltaTime;
        }
        speed += acceleration * Time.deltaTime;
        transform.position += velocity.normalized * speed * Time.deltaTime;

        if(Vector3.Distance(transform.position, player.position) < radius)
        {
            Destroy(gameObject);
            Debug.Log("blow up");
        }
    }
}
