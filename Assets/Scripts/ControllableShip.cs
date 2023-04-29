using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControllableShip : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public ParentConstraint constraint;
    public Vector2 acceleration;
    public int pointCt = 60;
    [Header("Trajectory Test Vars")] 
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
            transform.up = contactNormal;
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
        lineRenderer.SetPositions(
            System.Array.ConvertAll(
                Utils.Math.AcceleratedVelocityPlot(new Ray2D(rb.position, rb.velocity), localAccel, pointCt, Time.fixedDeltaTime), 
                x => (Vector3)x
            ));
    }
}
