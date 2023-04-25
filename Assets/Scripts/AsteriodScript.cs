using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodScript : MonoBehaviour
{
    public int points;
    public float range;
    public PolygonCollider2D col;
    public MeshFilter mFil;
    // Start is called before the first frame update
    void Start()
    {
        //Gen Rand Points
        Vector2[] colliderPoints = new Vector2[points];
        float section = 360f / colliderPoints.Length;
        for (int i = 0; i < colliderPoints.Length; i++)
        {
            float angle = section * i;
            Vector2 normal = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
            normal *= Random.value * range;
            colliderPoints[i] = normal;
            
        }
        col.points = colliderPoints;



        //Generate mesh
        Mesh colMesh = col.CreateMesh(false, false);
        mFil.mesh = colMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
