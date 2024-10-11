using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player;
    Vector2 distance;
    Vector3 velocity = Vector2.zero;
    float speed = 1f;

    //Space Shooter mechanic 3
    public GameObject bomb;
    float timer = 0;
    private void Start()
    {
        distance = player.position - transform.position;
    }
    private void Update()
    {
        EnemyMovement();

        //The third final space shooter mechanic will be placed in update for ease of visibility
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            timer = 0;
        }
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
