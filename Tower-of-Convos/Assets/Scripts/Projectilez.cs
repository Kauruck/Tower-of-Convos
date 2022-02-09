using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilez : MonoBehaviour
{
    public float speed = 1;
    private Transform target;
    private Vector3 target2;
    private Rigidbody rb;

    private void Start()
    {
        target2 = new Vector3(0,0,0);
        //position = gameObject.transform.position;
        target = FindTarget();
        rb = GetComponent<Rigidbody>();
    }
    

    public Transform FindTarget()
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag("Fish");
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (candidates.Length == 0)
            return null;

        closest = candidates[0].transform;
        for (int i = 1; i < candidates.Length; ++i)
        {
            float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                closest = candidates[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }
    void Update()
    {
         
         transform.position = Vector3.MoveTowards(this.transform.position,FindTarget().transform.position, 1);
    }
}


