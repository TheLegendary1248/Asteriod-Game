using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodGen : MonoBehaviour
{

    public float count;
    public float range;
    public GameObject objtospawn;
    public void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 pos = Random.insideUnitCircle * range;
            Instantiate(objtospawn, pos, Quaternion.identity); 
        }
        
    }
}
