using System.IO;
using UnityEngine;

public class UploadFileLog : MonoBehaviour
{
    private string path;
    // bool which menu active
    public GameObject mainmenu;
    public GameObject csvMenu;

    void Start()
    {
        path = Application.dataPath + "/CurrentFile.txt";
    }

    void setpath()
    {
        path = Application.dataPath + "/CurrentFile.txt";
    }

    public void overWriteName(string filename)
    {
        setpath();
        File.WriteAllText(path, filename);
    }

    public string getFileName()
    {
        setpath();
        return File.ReadAllText(path);

    }

}
