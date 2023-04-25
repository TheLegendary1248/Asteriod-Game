using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ControllableShip : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public ParentConstraint constraint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            constraint.constraintActive = false;
            Vector2 toMouseNormal = -((Vector2)transform.position - CameraPanner.MousePos()).normalized;
            rb.velocity = toMouseNormal * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Snap ship to asteriod
        if(!constraint.constraintActive)
        {
            ConstraintSource src = new ConstraintSource();
            src.weight = 1f;
            src.sourceTransform = collision.transform;
            constraint.SetSource(0, src);
            constraint.constraintActive = true;
            constraint.SetTranslationOffset(0, collision.transform.InverseTransformPoint(transform.position));
        }
        
    }
}
