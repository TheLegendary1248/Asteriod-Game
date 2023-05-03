using UnityEngine;
using UnityEditor;
using System;

public class PolygonFill : MonoBehaviour, IPlotable
{
    public PolygonCollider2D polyCollider;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public LineRenderer outline;

    public Vector3[] Outline()
    {
        Vector3[] line = new Vector3[outline.positionCount];
        outline.GetPositions(line);
        return line;
    }

    public Func<float, Vector2> PredictPath()
    {
        return (float time) => polyCollider.attachedRigidbody.position + (polyCollider.attachedRigidbody.velocity * time);
    }
    public Func<float, Quaternion> PredictRotation()
    {
        return (float time) => polyCollider.transform.rotation * Quaternion.Euler(0, 0, polyCollider.attachedRigidbody.angularVelocity * time);
    }

    // Start is called before the first frame update
    void Start()
    {

        //Generate mesh
        Mesh colMesh = polyCollider.CreateMesh(false, false);
        //Fix Mesh UV
        colMesh.uv = System.Array.ConvertAll(colMesh.vertices, i => (Vector2)i);
        meshFilter.mesh = colMesh;
        //Setup outline
        outline.positionCount = polyCollider.points.Length;
        outline.SetPositions(System.Array.ConvertAll(polyCollider.points, i => (Vector3)i));
        //Rand shader origin
        
    }

    
}
