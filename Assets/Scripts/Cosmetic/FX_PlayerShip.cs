using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_PlayerShip : MonoBehaviour
{
    public GameObject mountParticles;
    public float lerp;
    [Tooltip("How much distance should the ship test for rotating to fit the landing site")]
    public float test_distance;
    public ControllableShip ship;
    public Collider2D col;
    private void FixedUpdate()
    {
        //Get cast
        int count = col.Raycast(ship.acceleration, new RaycastHit2D[1], test_distance);
        

        Vector2 normal = ship.acceleration;
        transform.eulerAngles = new Vector3(0f, 0f, Mathf.LerpAngle(transform.eulerAngles.z, Mathf.Atan2(normal.y, normal.x), lerp));
        
        
    }
}
