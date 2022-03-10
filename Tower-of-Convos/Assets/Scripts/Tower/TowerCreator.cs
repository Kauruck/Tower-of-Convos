using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreator : MonoBehaviour
{
    public int money = 20000;
    private int clickCheck;
    private GameObject p;
    public GameObject p1;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public List<Vector2> towerpos = new List<Vector2>();
    public List<GameObject> towers = new List<GameObject>();
    public List<GameObject> checkers = new List<GameObject>();
    private bool check = false;
    private bool check2 = false;
    public Vector2 nWorldPosition;
    public Vector3 worldPosition;
    public Vector3 tempPos;
    private List<RaycastHit2D> hit = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempPos = Input.mousePosition;
            //Debug.Log(tempPos);
            tempPos.z = -(Camera.main.transform.position.z);
            worldPosition = Camera.main.ScreenToWorldPoint(tempPos);
            //Debug.Log(worldPosition);
            nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);
            Debug.Log(nWorldPosition);
            if (money > 750)
            {

                
                
                   // Debug.Log(money);
                    //Debug.Log("placed");

                    p = (GameObject)Instantiate(P1, nWorldPosition, this.transform.rotation);
                p.name = "Test object";
                
                    if (p.GetComponent<SpawnCollider>().mCheckCollider(worldPosition) == false)
                    {
                        //Debug.Log(p.GetComponent<SpawnCollider>().checkCollider);
                        p1 = (GameObject)Instantiate(P2, nWorldPosition, this.transform.rotation);
                    p.GetComponent<SpawnCollider>().f = p1;
                    money = money - 750;
                    towers.Add(p1);
                    checkers.Add(p);
                }
                    else {
                    Destroy(p) ;
                        }
                    
                    towerpos.Add(nWorldPosition);
                    
                
                check = false;
            }
            

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            RaycastHit2D hit1 = Physics2D.Raycast(nWorldPosition, Vector2.zero, 1f, LayerMask.GetMask("SpawnCollider"));
            hit1.collider.GetComponent<SpawnCollider>().Hud = true;
            P3 = hit1.collider.gameObject;

        }






    }
    void FixedUpdate()
    {
        money = money + 3;

    }
}

