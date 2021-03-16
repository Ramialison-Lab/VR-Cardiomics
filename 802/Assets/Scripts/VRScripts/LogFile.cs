using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogFile : MonoBehaviour
{
    private string path;

    private void Start()
    {
        path = Application.dataPath + "/SessionLog.txt";
        File.WriteAllText(path, "Logfile \n\n");
        File.AppendAllText(path, "Time of session start: " + System.DateTime.Now + "\n \n");
        File.AppendAllText(path, "*********************************************************\n\n");

    }



    public void writeToFile(string gene, bool copy)
    {
        gene = gene.Replace("<i>", "");
        gene = gene.Replace("</i>", "");
        if (copy) File.AppendAllText(path, gene + " selected at: " + System.DateTime.Now.ToString("HH:MM:ss") + " for the combined view model. \n") ;
        if (!copy) File.AppendAllText(path, gene + " selected at: " + System.DateTime.Now.ToString("HH:MM:ss") + " for the original model. \n");

    }
}
