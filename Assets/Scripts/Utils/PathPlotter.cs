using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlotter : MonoBehaviour
{
    public LineRenderer line;
    public float endTime;
    public GameObject currentSelected;
    private void Update()
    {
        //Get object with plotable interface 
        Collider2D collider = Physics2D.OverlapPoint(CameraPanner.MousePos());
        if (collider) currentSelected = collider.gameObject;
            else if (!currentSelected) return;

        IPlotable plot = currentSelected.GetComponent<IPlotable>();

        //Set visuals
        line.gameObject.transform.position = plot.PredictPath()(2f);
        line.gameObject.transform.rotation = plot.PredictRotation()(2f);
        Vector3[] outline = plot.Outline();
        line.positionCount = outline.Length;
        line.SetPositions(outline);
    }
    //The below is going to be used with the above as eye candy
    /// <summary>
    /// Lerps between shapes defined by the given points
    /// </summary>
    /// <param name="fromShape"></param>
    /// <param name="toShape"></param>
    /// <param name="interpolation"></param>
    /// <returns></returns>
    Vector2[] FancyShapeLerp(Vector2[] fromShape, Vector2[] toShape, float interpolation)
    {
        int maxCount = Mathf.Max(fromShape.Length, toShape.Length);
        
        for (int i = 0; i < maxCount; i++)
        {

        }
        throw new System.NotImplementedException();
    }
}
