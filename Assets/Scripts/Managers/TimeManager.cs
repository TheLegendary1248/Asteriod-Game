using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int frameCount = 320;
    public int i;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            i = 0;
            Time.timeScale = 1;
        }
    }
    private void FixedUpdate()
    {
        if (i >= frameCount)
        {
            Time.timeScale = 0;
        }
        i++;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
