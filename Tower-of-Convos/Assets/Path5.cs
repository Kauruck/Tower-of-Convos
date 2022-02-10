using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Path5 : MonoBehaviour
{

    float x;
    double y;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-145, -28, 0);
    }

    // Update is called once per frame
    void Update()
    {
        x = this.transform.position.x;
        y = 0.000021*Math.Pow(x-50,3)+0.0035*Math.Pow(x-50,2);
        transform.position = new Vector3(x+1,(float)y,0);
    }
}
