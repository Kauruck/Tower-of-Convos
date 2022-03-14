using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public float Speed;

    public PathHolder path;

    public float x = 0;

    private float LookAtOffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(path != null){
            this.transform.position = path.getPointOnCurves(x);
            if(x + LookAtOffset <= path.PathLength){
                transform.right = ((Vector3)path.getPointOnCurves(x + LookAtOffset)) - transform.position;
            }
            x += Speed;
            if(x >= path.PathLength)
                x = path.PathLength;
            }
    }
}
