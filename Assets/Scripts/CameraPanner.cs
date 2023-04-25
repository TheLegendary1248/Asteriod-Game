using UnityEngine;

public class CameraPanner : MonoBehaviour
{
    public Vector2 focus = Vector2.zero;
    public float speed = 100f;
    public float lerp = 0.02f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            focus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        focus += new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.deltaTime * speed;
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y * (Camera.main.orthographicSize / 30);
        transform.position = Vector3.Lerp(transform.position, (Vector3)focus + Vector3.back, lerp);
    }
    public static Vector2 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public static Vector2 MousePos(Camera c)
    {
        return c.ScreenToWorldPoint(Input.mousePosition);
    }
}
