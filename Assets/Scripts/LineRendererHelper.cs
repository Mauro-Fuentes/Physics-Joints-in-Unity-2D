using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererHelper : MonoBehaviour
{
    private LineRenderer line;
    public Transform position1;
    public Transform position2;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPosition(0, position1.position);
        line.SetPosition(1, position2.position);
    }
}
