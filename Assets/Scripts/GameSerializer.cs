using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameSerializer : MonoBehaviour
{

    public void LoadGame()
    {
        
    }
    public void SaveGame()
    {
        //Get saves folder
        string constPath = Application.persistentDataPath;
            //Add save folder directory to path here

        //Get all objects that need serializations
        GameObject[] serialize = null;
        for (int i = 0; i < serialize.Length; i++)
        {

        }
        string filepath = "path";
        //Write to file
        using(File.OpenWrite(filepath))
        {

        }
        //Confirm to UI Dialogue
    }

}
