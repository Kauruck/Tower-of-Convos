using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bessererPathCreator : MonoBehaviour
{
    public GameObject P1;
    float x;
    double y;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-160,-0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(x<200){

            x = this.transform.position.x;
            y = 0.000021*Math.Pow(x-50,3)+0.0035*Math.Pow(x-50,2);
            transform.position = new Vector3(x+1,(float)y,0);

            object p = Instantiate(P1, this.transform.position, this.transform.rotation);
        
        }
    }
}
