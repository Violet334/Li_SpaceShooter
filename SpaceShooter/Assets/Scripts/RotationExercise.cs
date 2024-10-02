using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExercise : MonoBehaviour
{
    public Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newTarget = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(newTarget.x, newTarget.y) * Mathf.Rad2Deg;
        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);
        if (transform.eulerAngles.z < angle)
        {
            transform.Rotate(0, 0, angle);
        }
        if (transform.eulerAngles.z > angle)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
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
