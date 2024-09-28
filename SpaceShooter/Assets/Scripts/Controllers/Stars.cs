using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    int i = 1;
    float timePassed = 0;
    float linePercent;
    // Update is called once per frame
   void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {
        timePassed += Time.deltaTime;
        linePercent = timePassed / drawingTime;
        if (timePassed >= drawingTime)
        {
            i++;
            timePassed = 0;
            if (i >= starTransforms.Count)
            {
                i = 1;
            }
        }
        Debug.DrawLine(starTransforms[i - 1].position,Vector3.Lerp(starTransforms[i - 1].position, starTransforms[i].position, linePercent), Color.white);
    }
}
