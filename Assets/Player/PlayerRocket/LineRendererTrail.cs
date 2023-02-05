using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTrail : MonoBehaviour
{
    LineRenderer lineRenderer;
    bool isTracing = true;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        Vector3[] emptyArray = new Vector3[0];
        lineRenderer.SetPositions(emptyArray);
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isTracing)
        {
            lineRenderer.enabled = true;

            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
        }
    }
}
