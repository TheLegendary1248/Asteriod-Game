using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PolygonColliderModifier
{
    //General Function...
    public static void Fracture(this PolygonFill self)
    {
        throw new System.NotImplementedException();
        bool tooSmall = false;
        if (tooSmall) { } //Simply delete if it's too small to fracture again
        else { } //Fracture code
    }
    //Splits the asteroid along the given ray
    public static void Split(this PolygonFill self, Ray r)
    {
        PolygonCollider2D collider = self.polyCollider;
        //Get line closest to ray origin
        int startPoint = ClosestLine(collider.points, r.origin);
        int endPoint = ClosestLine(collider.points, Vector2.zero);
        //Get line closest to split exit point
        
        //Generate half

        //Generate fragment other half
    }
    #region EXTRA
    //Dents the collider in said direction
    public static void Dent(this PolygonFill self, Ray r)
    {

    }
    //Splits the collider in several directions from a given center
    public static void Crack(this PolygonFill self, Vector2 center, Ray[] along)
    {

    }
    #endregion
    //Returns the lower index of the line pair that is closer to the point
    public static int ClosestLine(Vector2[] shape, Vector2 point)
    {
        for (int i = 0; i < shape.Length; i++)
        {
            Vector2 start = shape[i];
            Vector2 end = shape[i % (shape.Length - 1)];
        }
        return 0;
    }
    public static float SquarePointDistanceToLine(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
    {
        float dividend = Mathf.Abs((lineEnd.x - lineStart.x) * (lineStart.y - point.y) - (lineStart.x - point.x) * (lineEnd.y - lineStart.y));
        float divisor = Mathf.Sqrt(Mathf.Pow(lineEnd.x - lineStart.x, 2) + Mathf.Pow(lineEnd.y - lineStart.y, 2));

        if (divisor != 0f)
        {
            return dividend / divisor;
        }
        else
        {   // pointoints lineStart and lineEnd are the same, choose one
            return Mathf.Pow(point.x - lineStart.x, 2) + Mathf.Pow(point.y - lineStart.y, 2);
        }
    }
    public static GameObject GenerateFragment()
    {
        throw new System.NotImplementedException();
    }
}
