using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic3Test : MonoBehaviour
{
    public GameObject bomb;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            timer = 0;
        }

    }
}
