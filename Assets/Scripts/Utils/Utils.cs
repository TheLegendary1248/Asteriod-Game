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

        public static Vector2[] AcceleratedVelocityPlot(Ray2D obj, Vector2 acceleration, int steps, float stepSize)
        {
            //Ensure conditions are correct
            if (steps <= 0) throw new System.ArgumentOutOfRangeException("Steps cannot be less than one");
            if (stepSize <= 0) throw new System.ArgumentOutOfRangeException("Step Size cannot be less than zero");
            //Initialize
            Vector2[] plot = new Vector2[steps];

            //Step through and generate
            for (int i = 0; i < steps; i++)
            {
                plot[i] = obj.origin + AccelerationDisplacement(obj.direction, acceleration, stepSize * i);
            }
            return plot;
        }

        /// <summary>
        /// Gets the position of an object after some amount of time given velocity and acceleration
        /// </summary>
        public static Vector2 AccelerationDisplacement(Vector2 velocity, Vector2 acceleration, float time) => (velocity * time) + (0.5f * acceleration * (time * time));
    }
}
