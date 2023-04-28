using UnityEngine;
using UnityEditor;
public class PolygonFill : MonoBehaviour
{
    public PolygonCollider2D polyCollider;
    public MeshFilter meshFilter;
    public LineRenderer outline;

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
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
