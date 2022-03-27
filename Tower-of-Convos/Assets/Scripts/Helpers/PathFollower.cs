using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public float Speed;

    public PathHolder path;

    public float x = 0;

    public float maxAngle = 90;

    public SpriteRenderer spriteToFlip;

    private float LookAtOffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (path != null)
        {
            Vector3 pos = path.getPointOnCurves(x);
            pos.z = 2;
            this.transform.position = pos;
            if (x + LookAtOffset <= path.PathLength)
            {
                transform.right = ((Vector3)path.getPointOnCurves(x + LookAtOffset)) - new Vector3(transform.position.x, transform.position.y, 0);
                float angle = Vector3.Angle(transform.right, Vector3.right);
                if (angle > maxAngle)
                {
                    transform.right = -transform.right;
                    spriteToFlip.flipX = true;
                }
                else
                {
                    spriteToFlip.flipX = false;
                }
            }
            x += Speed;
            if (x >= path.PathLength)
                x = path.PathLength;
        }
    }
}
