using UnityEngine;
using UnityEditor;
public class AsteriodScript : MonoBehaviour
{
    public int points;
    public float nodeRange;
    public Vector2 range;
    public PolygonCollider2D col;
    public MeshFilter mFil;
    Vector2[] nodes;
    public LineRenderer outline;
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



        //Generate mesh
        Mesh colMesh = col.CreateMesh(false, false);
        //Fix Mesh UV
        colMesh.uv = System.Array.ConvertAll(colMesh.vertices, i => (Vector2)i);
        mFil.mesh = colMesh;
        //Setup outline
        outline.positionCount = colliderPoints.Length;
        outline.SetPositions(System.Array.ConvertAll(colliderPoints, i => (Vector3)i));
    }
    //Script to split the asteroid with enough damage or whatever other condition
    void Fracture()
    {
        throw new System.NotImplementedException();
        bool tooSmall = false;
        if (tooSmall) { } //Simply delete if it's too small to fracture again
        else { } //Fracture code
    }
    //Splits the asteroid along the given ray
    void Split(Ray r)
    {

    }
    //Modifies the shape of the asteroid
    void Dent()
    {
          
    }
    
    void Crack(Vector2 center, Ray[] along)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        if (nodes != null) for (int i = 0; i < nodes.Length; i++) Handles.DrawWireDisc(transform.TransformPoint(nodes[i]), Vector3.forward, .25f);
    }
}
