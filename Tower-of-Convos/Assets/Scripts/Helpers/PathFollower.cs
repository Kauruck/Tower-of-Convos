using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public float Speed;

    public PathHolder path;

    public float x = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(path != null){
            this.transform.position = path.getPointOnCurves(x);
            x += Speed;
            if(x >= path.PathLength)
                x = path.PathLength;
            }
    }
}
