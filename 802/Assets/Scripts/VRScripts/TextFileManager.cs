using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class TextFileManager : MonoBehaviour
{
    private string path;
    public GameObject filename;

    public void writeTextfile()
    {
        path = Application.dataPath + "/SessionLog.txt";

    }
}
