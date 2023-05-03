using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlotable
{
    /// <summary>
    /// Returns a delegate that tells the path of this projectile at the given time
    /// </summary>
    System.Func<float, Vector2> PredictPath();

    System.Func<float, Quaternion> PredictRotation();

    /// <summary>
    /// An outline the plotter can use to show the object at selective times
    /// </summary>
    /// <returns></returns>
    Vector3[] Outline();
}
