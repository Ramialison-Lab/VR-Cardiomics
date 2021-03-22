using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogFile : MonoBehaviour
{
    private string path;
    private bool save =true;
    private bool compareModel;
    private void Start()
    {
        path = Application.dataPath + "/SessionLog.txt";
           File.WriteAllText(path, "Logfile \n\n" + System.DateTime.Now + "\n \n");
           File.AppendAllText(path, "*********************************************************\n\n");

           File.AppendAllText(path, "Main Gene selected \t\t\t\t Compared with \t\t\t\t Timestamp \n");
        File.AppendAllText(path, "_________________________________________________________________________________\n\n");
    }
    public void compareModelWrite()
    {
        compareModel = true;
        File.AppendAllText(path, "\nThe Combinded View Model was enabled at: " + System.DateTime.Now.ToString("HH:MM:ss") + "\n");
        compareModel = !compareModel;
    }

    public void compareModelReset()
    {
        if (!compareModel) File.AppendAllText(path, "The Combinded View Model was disabled at: " + System.DateTime.Now.ToString("HH:MM:ss") + " due to a reset.\n");

    }


    public void writeToFile(string gene, bool copy)
    {
        gene = gene.Replace("<i>", "");
        gene = gene.Replace("</i>", "");

        if (save && copy)
        {
            //both copies
            File.AppendAllText(path, "-----\t\t\t\t" +gene+ "\t\t\t\t" + System.DateTime.Now.ToString("HH:MM:ss") + "\n");

        }
        if (!save && !copy)
        {
            //both are original 
            File.AppendAllText(path, "\t\t\t\t------- \t\t\t\t" + System.DateTime.Now.ToString("HH:MM:ss") +"\n");
            File.AppendAllText(path, gene);
        }
        if (!save && copy)
        {
            //last copy new original 
            File.AppendAllText(path, "\t\t\t\t" + gene + "\t\t\t\t" + System.DateTime.Now.ToString("HH:MM:ss") + "\n");
        }
        if (save && !copy)
        {
            //last copy new original 
            File.AppendAllText(path, gene);
        }
        save = copy;
    }
}
