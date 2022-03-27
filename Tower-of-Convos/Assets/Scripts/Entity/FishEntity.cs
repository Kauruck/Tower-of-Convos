using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFollower))]
[RequireComponent(typeof(Entity))]
public class FishEntity : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Swimming", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
