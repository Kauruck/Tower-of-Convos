using UnityEngine;
public class Path : MonoBehaviour
{
    void Start()
    {
        int movespeed = 0;
        transform.position = new Vector3(transform.position.x + movespeed, transform.position.y);
        Vector3 position = this.transform.position;
        transform.position = new Vector3(-130, 30, 0);
        
    }
    private void Update()
    {
        Vector3 position = this.transform.position;

       
        position.x++;
        this.transform.position = position;
        
    }
}