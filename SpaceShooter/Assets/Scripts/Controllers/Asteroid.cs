using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float moveSpeed = 6;
    public float arrivalDistance;
    float maxFloatDistance = 4;
    float maxDistanceRange;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        maxDistanceRange = Random.Range(-maxFloatDistance, maxFloatDistance);
        direction = new Vector3(transform.position.x + maxDistanceRange, transform.position.y + maxDistanceRange);
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {   
        Vector3 velocity = Vector3.zero;
        velocity += direction * moveSpeed * Time.deltaTime;
        transform.position += velocity * moveSpeed * Time.deltaTime;
        if ((direction.x-transform.position.x) < arrivalDistance ||(direction.y-transform.position.y) < arrivalDistance)
        {
            maxDistanceRange = Random.Range(-maxFloatDistance, maxFloatDistance);
            direction = new Vector3(transform.position.x + maxDistanceRange, transform.position.y + maxDistanceRange);
            //Debug.Log("changed destination");
        }
    }
}
