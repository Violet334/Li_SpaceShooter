using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Missile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float moveSpeed ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        FollowPlayer();
    }

    void LookAtTarget()
    {
        Vector3 currentDir = transform.up;
        float currentAngle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg;
        Vector3 targetDir = target.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(currentAngle, targetAngle);
        if (deltaAngle > 0)
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
        else if (deltaAngle < 0)
        {
            transform.Rotate(0f, 0f, -speed * Time.deltaTime);
        }
    }

    void FollowPlayer()
    {
        Vector3 targetDir = target.position - transform.position;
        if (Vector3.Distance(transform.position, target.position) >= 0.3)
        {
            transform.position += targetDir.normalized * moveSpeed ;
        }
        if(Vector3.Distance(transform.position, target.position) < 0.3)
        {
            Destroy(gameObject);
        }
    }
}
