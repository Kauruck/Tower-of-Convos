using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HUDChecker : MonoBehaviour
{
    private List<RaycastHit2D> hit = new List<RaycastHit2D>();
    public Vector2 nWorldPosition;
    public Vector3 worldPosition;
    private Vector3 tempPos;
    public GameObject f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ContactFilter2D filter = new ContactFilter2D();
            filter.layerMask = LayerMask.GetMask("SpawnCollider");
            tempPos = Input.mousePosition;
            //Debug.Log(tempPos);
            tempPos.z = -(Camera.main.transform.position.z);
            worldPosition = Camera.main.ScreenToWorldPoint(tempPos);
            //Debug.Log(worldPosition);
            nWorldPosition = new Vector2(worldPosition.x, worldPosition.y);
            Debug.Log(nWorldPosition);
            //Physics2D.Raycast(worldPoint, Vector2.zero, filter, hit, 1);
            RaycastHit2D hit1 = Physics2D.Raycast(nWorldPosition, Vector2.zero, 1f, LayerMask.GetMask("SpawnCollider")) ;

            if (hit1.collider != null)
            {
                Debug.Log("Target name: " + hit1.collider.name);
            }
            if (hit1.collider == this.gameObject)
            {

              
                    Debug.Log("Gameing");
                    f.GetComponent<TestMover>().Hud = true;


                

            }


        }*/
    }

}