using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static class Math
    {   //Common math functions
        public static Vector2[] PlotPoints()
        {
            throw new System.NotImplementedException();
        }

        public static Vector2[] AcceleratedVelocity(Ray2D obj, Vector2 acceleration, int steps, float stepSize)
        {
            //Ensure conditions are correct
            if (steps <= 0) throw new System.ArgumentOutOfRangeException("Steps cannot be less than one");
            if (stepSize <= 0) throw new System.ArgumentOutOfRangeException("Step Size cannot be less than zero");
            //Initialize
            Vector2[] plot = new Vector2[steps];
            Ray2D objAtPoint = obj;

            //Step through and generate
            for (int i = 0; i < steps; i++)
            {
                plot[i] = objAtPoint.origin;
                objAtPoint.direction += acceleration * stepSize;
                objAtPoint.origin += obj.direction * stepSize;
            }
            return plot;
        }
    }
}
