using UnityEngine;


public class TextFileManager : MonoBehaviour
{
    private string path;
    public GameObject filename;

    public void writeTextfile()
    {
        path = Application.dataPath + "/SessionLog.txt";

    }
}
