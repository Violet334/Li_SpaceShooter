using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player;
    Vector2 distance;
    Vector3 velocity = Vector2.zero;
    float speed = 1f;
    private void Start()
    {
        distance = player.position - transform.position;
    }
    private void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        Vector2 currentDist = player.position - transform.position;
        
        if(currentDist.x > distance.x)
        {
            velocity = Vector2.zero;
            velocity += Vector3.right * speed * Time.deltaTime;
        } else if(currentDist.x < distance.x)
        {
            velocity = Vector2.zero;
            velocity += Vector3.left * speed * Time.deltaTime;
        }
        if(currentDist.y > distance.y)
        {
            velocity = Vector2.zero;
            velocity += Vector3.up * speed * Time.deltaTime;
        } else if(currentDist.y < distance.y)
        {
            velocity = Vector2.zero;
            velocity += Vector3.down * speed * Time.deltaTime;
        }
        transform.position += velocity.normalized * speed * Time.deltaTime;
    }
}
