using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path2 : MonoBehaviour
{
    private float speed = 10.0f;
private Vector2 target;
private Vector2 position;
private Camera cam;
    private int checkpoint = 0;
// Start is called before the first frame update
void Start()
{
        transform.position = new Vector3(-130, 30, 0);
        target = new Vector2(6.0f, 28.0f);
    position = gameObject.transform.position;

}

// Update is called once per frame
void Update()
{
    float step = speed * Time.deltaTime;

        // move sprite towards the target location
        if (transform.position.x == 6 && transform.position.y == 28)
        {
            checkpoint = 1;
            transform.Rotate(Vector3.forward * -90);
        }
        if (transform.position.x == 6 && transform.position.y == 2)
        {
            checkpoint = 2;
            transform.Rotate(Vector3.forward * -90);
        }
        if (transform.position.x == -63 && transform.position.y == 0)
        {
            checkpoint = 3;
            transform.Rotate(Vector3.forward * 90);
        }
        if (transform.position.x == -63 && transform.position.y == -29)
        {
            checkpoint = 4;
            transform.Rotate(Vector3.forward * 90);
        }
        if (transform.position.x == 54 && transform.position.y == -29)
        {
            checkpoint = 5;
            transform.Rotate(Vector3.forward * 90);
        }
        if (transform.position.x == 54 && transform.position.y == 30)
        {
            checkpoint = 6;
            transform.Rotate(Vector3.forward * -90);
        }
        if (transform.position.x == 84 && transform.position.y == 30)
        {
            checkpoint = 7;
            transform.Rotate(Vector3.forward * -90);
        }
        if (checkpoint == 1)
        {
            target = new Vector2(6.0f, 2.0f);
        }
        if (checkpoint == 2)
        {
            target = new Vector2(-63.0f, 0.0f);
        }
        if (checkpoint == 3)
        {
            target = new Vector2(-63.0f, -29.0f);
        }
        if (checkpoint == 4)
        {
            target = new Vector2(54.0f, -29.0f);
        }
        if (checkpoint == 5)
        {
            target = new Vector2(54.0f, 30.0f);
        }
        if (checkpoint == 6)
        {
            target = new Vector2(84.0f, 30.0f);
        }
        if (checkpoint == 7)
        {
            target = new Vector2(87.0f, -48.0f);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        
}
}
 