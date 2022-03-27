using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(PathHolder))]
public class PathRenderer : MonoBehaviour
{

    public GameObject pathElement;
    public float distanceBetweenMarker;
    public float distanceToLine = 1;
    private PathHolder holder;

    [HideInInspector]
    [SerializeField]
    private List<GameObject> pathElements = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        this.holder = this.GetComponent<PathHolder>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generateTexture()
    {
        foreach (GameObject obj in pathElements)
        {
            GameObject.DestroyImmediate(obj);
        }
        const float stepSize = 1f / 100;
        float lastDistance = 0;
        Vector2 lastPoint = holder[0f];
        //Outer Ring
        for (float t = 0; t <= holder.maxT; t += stepSize)
        {
            Vector2 point = holder[t];
            lastDistance += Vector2.Distance(lastPoint, point);
            lastPoint = point;
            if (lastDistance >= distanceBetweenMarker)
            {
                BezierCurve curve = holder.getCurveForT(t);
                float localT = t - Mathf.FloorToInt(t);
                Vector2 normal = BezierHelper.getNormalForCurve(curve, localT, stepSize);
                Vector3 spawnPoint;
                List<Vector2> points = LineHelper.generateSattilits(point, normal, distanceToLine);
                if (LineHelper.onLeftSide(point, point + normal, points[0]))
                {
                    spawnPoint = points[0];
                }
                else
                {
                    spawnPoint = points[1];
                }
                spawnPoint.z = this.transform.position.z;
                GameObject obj = GameObject.Instantiate(pathElement, spawnPoint, Quaternion.identity);
                obj.transform.SetParent(this.gameObject.transform);
                pathElements.Add(obj);
                lastDistance = 0;
            }
        }
        //Inner Ring
        for (float t = 0; t <= holder.maxT; t += stepSize)
        {
            Vector2 point = holder[t];
            BezierCurve curve = holder.getCurveForT(t);
            float localT = t - Mathf.FloorToInt(t);
            Vector2 normal = BezierHelper.getNormalForCurve(curve, localT, stepSize);
            Vector3 spawnPoint;
            List<Vector2> points = LineHelper.generateSattilits(point, normal, distanceToLine);
            if (!LineHelper.onLeftSide(point, point + normal, points[0]))
            {
                spawnPoint = points[0];
            }
            else
            {
                spawnPoint = points[1];
            }
            lastDistance += Vector2.Distance(lastPoint, spawnPoint);
            lastPoint = spawnPoint;
            if (lastDistance >= distanceBetweenMarker)
            {
                spawnPoint.z = this.transform.position.z;
                GameObject obj = GameObject.Instantiate(pathElement, spawnPoint, Quaternion.identity);
                obj.transform.SetParent(this.gameObject.transform);
                pathElements.Add(obj);
                lastDistance = 0;
            }
        }
    }

}
