using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreator : MonoBehaviour
{
    public int money = 20000;
    private GameObject p;
    private GameObject p1;
    public GameObject SpawnCollider;
    public GameObject ShootTower;
    public List<Vector2> towerpos = new List<Vector2>();
    public List<GameObject> towers = new List<GameObject>();
    public List<GameObject> checkers = new List<GameObject>();
    private bool check = false;
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
            tempPos.z = -(Camera.main.transform.position.z);
            worldPosition = Camera.main.ScreenToWorldPoint(tempPos);
            nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);
            if (money > 750)
            {
                p = (GameObject)Instantiate(SpawnCollider, nWorldPosition, Quaternion.identity);
                p.name = "Test object";
                
                if (p.GetComponent<SpawnCollider>().mCheckCollider(worldPosition) == false)
                {
                    
                    p1 = (GameObject)Instantiate(ShootTower, nWorldPosition, Quaternion.identity);
                    p.GetComponent<SpawnCollider>().tower = p1;
                    money = money - 750;
                    towers.Add(p1);
                    checkers.Add(p);
                }
                else {
                    Destroy(p);
                }
                
                towerpos.Add(nWorldPosition);
                check = false;
            }
        }
    }
    void FixedUpdate()
    {
        money = money + 3;

    }
}

