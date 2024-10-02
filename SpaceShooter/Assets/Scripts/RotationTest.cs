using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angularSpeed;
    public float targetAngle;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.up);
        if (transform.eulerAngles.z < targetAngle)
        {
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        }
        if (transform.eulerAngles.z > targetAngle)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, targetAngle);
        }
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;
        inAngle = (inAngle + 360) % 360;
        if (inAngle > 180)
        {
            inAngle -= 360;
        }
        return (inAngle);
    }
}
