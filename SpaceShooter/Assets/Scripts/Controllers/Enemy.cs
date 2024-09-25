using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject bomb;
    private void Update()
    {
    }

    void SpawnBomb()
    {
        Instantiate(bomb, transform.up, Quaternion.identity);
    }
}
