using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Action", menuName = "SO/Action", order = 1)]
public class SO_Action : ScriptableObject
{
    [Tooltip("Path references to prefabs in Resources")]
    public GameObject prefab;
    public virtual void Use(UserInfo info)
    {
        GameObject gb = Instantiate(prefab, info.launch.origin, Quaternion.identity);
        //TODO: Pass info to gameobject component
    }
}
public struct UserInfo
{
    public GameObject user;
    public Ray2D launch;
}
