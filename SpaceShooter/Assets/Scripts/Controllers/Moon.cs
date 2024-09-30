using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float rad;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(rad, speed, planetTransform);
    }
    void OrbitalMotion(float radius, float orbitalSpeed, Transform target)
    {
        Vector3 velocity = Vector3.zero;
        float i = 0;
        i+=orbitalSpeed*Time.deltaTime;
        Debug.Log(i);
        if (i >= 360)
        {
            i = 0;
        }
        Vector3 angle = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad)) * radius + target.position;
        velocity += angle * orbitalSpeed * Time.deltaTime;
        transform.position += velocity.normalized * orbitalSpeed * Time.deltaTime;
    }
}
