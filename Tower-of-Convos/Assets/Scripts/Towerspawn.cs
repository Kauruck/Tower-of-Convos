using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerspawn : MonoBehaviour
{
    public int money = 0;
    public GameObject P1;
    public List<Vector2> towers = new List <Vector2>();
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);
            Debug.Log(nWorldPosition);
            if (money > 750)
            {

                for(int i = 0; i<towers.Count; i++)
                {
                    if(towers[i].x+15 > nWorldPosition.x && nWorldPosition.x > towers[i].x-15 && towers[i].y+15 > nWorldPosition.y && nWorldPosition.y > towers[i].y-15)
                    {
                        check = true;
                        Debug.Log("Kannanich");
                    }
                    

                }
                if (check == false)
                {
                    Debug.Log(money);
                    Debug.Log("placed");
                    object p = Instantiate(P1, nWorldPosition, this.transform.rotation);
                    towers.Add(nWorldPosition);
                    money = money - 750;
                }
                check = false;
            }
        }
    }
    void FixedUpdate()
    {
        money= money +3;
        
    }
}
