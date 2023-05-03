using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControllableShip : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParentConstraint constraint;
    [Tooltip("The acceleration of the ship relative to itself")]
    public Vector2 acceleration;
    
    public Vector2 mountSpeed;
    public float launchSpeedCap;
    [Header("Trajectory Test Vars")] 
    public int pointCt = 60;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        TestTrajectoryStart();
    }
    public void FixedUpdate()
    {
        if(!constraint.constraintActive)
        {
            transform.up = acceleration;
        }
        rb.AddForce(acceleration * rb.mass);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            constraint.constraintActive = false;
            acceleration = (-rb.position + CameraPanner.MousePos());

            Vector2 localAccel = (-rb.position + CameraPanner.MousePos());
            Vector3[] plot = System.Array.ConvertAll(
                Utils.Math.AcceleratedVelocityPlot(rb.position, rb.velocity, localAccel, pointCt / 4, Time.fixedDeltaTime * 4f),
                x => (Vector3)x);

            for (int i = 0; i < plot.Length - 1; i++)
            {
                Debug.DrawLine(plot[i], plot[i + 1], Color.yellow, 2f);
            }
        }
        TestTrajectoryUpdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Snap ship to asteriod
        if (!constraint.constraintActive)
        {
            ConstraintSource src = new ConstraintSource();
            src.weight = 1f;
            src.sourceTransform = collision.transform;
            constraint.SetSource(0, src);
            constraint.constraintActive = true;
            constraint.SetTranslationOffset(0, collision.transform.InverseTransformPoint(transform.position));
            Vector2 contactNormal = collision.GetContact(0).normal;
            rb.velocity = rb.velocity.magnitude * contactNormal;
            transform.right = contactNormal;
        }
    }
    void TestTrajectoryStart()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }
    void TestTrajectoryUpdate()
    {
        lineRenderer.positionCount = pointCt;
        Vector2 localAccel = (-rb.position + CameraPanner.MousePos());
        Vector3[] plot = System.Array.ConvertAll(
            Utils.Math.AcceleratedVelocityPlot(rb.position, rb.velocity, localAccel, pointCt, Time.fixedDeltaTime),
            x => (Vector3)x);
        lineRenderer.SetPositions(plot);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)acceleration);
    }
}
