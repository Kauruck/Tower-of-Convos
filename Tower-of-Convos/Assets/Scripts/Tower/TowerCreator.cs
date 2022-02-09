using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreator : MonoBehaviour
{
    public int money;
    private GameObject p;
    public GameObject P1;
    public List<Vector2> towerpos = new List<Vector2>();
    public List<GameObject> towers = new List<GameObject>();
    public bool check = false;
    public bool check2 = false;
    public Vector2 nWorldPosition;
    public Vector3 worldPosition;
    private Vector3 tempPos;
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
            Debug.Log(tempPos);
            tempPos.z = -(Camera.main.transform.position.z);
            worldPosition = Camera.main.ScreenToWorldPoint(tempPos);
            Debug.Log(worldPosition);
            nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);
            Debug.Log(nWorldPosition);
            if (money > 750)
            {

                for (int i = 0; i < towerpos.Count; i++)
                {
                    if (towerpos[i].x + 3 > nWorldPosition.x && nWorldPosition.x > towerpos[i].x - 3 && towerpos[i].y + 3 > nWorldPosition.y && nWorldPosition.y > towerpos[i].y - 3)
                    {
                        check = true;
                        Debug.Log("Kannanich");
                    }
                   

                }
                if (check == false)
                {
                    Debug.Log(money);
                    Debug.Log("placed");
                    p = (GameObject)Instantiate(P1, nWorldPosition, this.transform.rotation);
                    towers.Add(p);
                    towerpos.Add(nWorldPosition);
                    money = money - 750;
                }
                check = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < towerpos.Count; i++)
            {
                if ((towerpos[i].x + 3) > nWorldPosition.x && nWorldPosition.x > (towerpos[i].x - 3) && (towerpos[i].y + 3) > nWorldPosition.y && nWorldPosition.y > (towerpos[i].y - 3) && check2 == false)
                {
                    check2 = true;

                }
            }
            void FixedUpdate()
            {
                money = money + 3;

            }
        }
    }
}
