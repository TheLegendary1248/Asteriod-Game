using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AsteroidShapeGenerator : MonoBehaviour
{
    public PolygonCollider2D col;
    public int points;
    public float nodeRange;
    public Vector2 range;
    Vector2[] nodes;
    // Start is called before the first frame update
    void Start()
    {
        float interpolate;
        const int MAX_NODES = 3;
        int nodeCount = Random.Range(1, MAX_NODES + 1);
        nodes = new Vector2[nodeCount];
        //Fill nodes array
        for (int i = 0; i < nodes.Length; i++) nodes[i] = Random.insideUnitCircle * nodeRange;


        //Gen Rand Points
        Vector2[] colliderPoints = new Vector2[points];
        float section = 360f / colliderPoints.Length;
        for (int i = 0; i < colliderPoints.Length; i++)
        {
            //Get dist from node
            float angle = section * i;
            Vector2 normal = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
            normal *= Random.RandomRange(range.x, range.y);
            //Get closest node
            Vector2 closest = Vector2.positiveInfinity;
            for (int k = 0; k < nodes.Length; k++)
            {
                Vector2 testNode = nodes[k];
                if ((testNode - normal).sqrMagnitude < closest.sqrMagnitude) closest = testNode;
            }
            colliderPoints[i] = normal + closest;

        }

        col.points = colliderPoints;
    }
    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        if (nodes != null) for (int i = 0; i < nodes.Length; i++) Handles.DrawWireDisc(transform.TransformPoint(nodes[i]), Vector3.forward, .25f);
    }
}
