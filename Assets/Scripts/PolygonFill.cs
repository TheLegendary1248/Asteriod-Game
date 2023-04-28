using UnityEngine;
using UnityEditor;
public class PolygonFill : MonoBehaviour
{
    public PolygonCollider2D col;
    public MeshFilter mFil;
    public LineRenderer outline;

    // Start is called before the first frame update
    void Start()
    {

        //Generate mesh
        Mesh colMesh = col.CreateMesh(false, false);
        //Fix Mesh UV
        colMesh.uv = System.Array.ConvertAll(colMesh.vertices, i => (Vector2)i);
        mFil.mesh = colMesh;
        //Setup outline
        outline.positionCount = col.points.Length;
        outline.SetPositions(System.Array.ConvertAll(col.points, i => (Vector3)i));
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
