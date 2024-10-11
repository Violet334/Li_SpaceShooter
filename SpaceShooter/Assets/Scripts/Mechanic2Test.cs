using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic2Test : MonoBehaviour
{
    public Transform asteroid;
    public float radius;

    public float speed;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test movement script
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += speed * Vector3.up * Time.deltaTime;
            transform.position += velocity.normalized * speed * Time.deltaTime;

            Vector3 offset = transform.position - asteroid.position;
            if (Vector3.Distance(transform.position, asteroid.position) < radius)
            {
                transform.position += offset + velocity.normalized * speed * Time.deltaTime;
            }
        }
    }
}
