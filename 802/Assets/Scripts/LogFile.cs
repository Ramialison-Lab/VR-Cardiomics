using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LogFile : MonoBehaviour
{
    private string path;
    private string genelistpath;
    private bool genelist = false;
    private bool save = true;
    private bool compareModel;
    private bool toggle = true;
    private int i = 0;
    private InputField geneInput;
    private void Start()
    {
        geneInput = GameObject.Find("InputGene").GetComponentInChildren<InputField>();
        path = Application.dataPath + "/SessionLog.txt";
        File.WriteAllText(path, "Logfile \n\n" + System.DateTime.Now + "\n \n");
        File.AppendAllText(path, "*********************************************************\n\n");

        File.AppendAllText(path, "Number of Object, GeneName, Normalised, timestamp \n");
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
        if (!compareModel) File.AppendAllText(path, "The Combinded View Model was disabled at: " + System.DateTime.Now.ToString("hh:mm:ss") + " due to a reset.\n");

    }


    public void writeToFile(string obj, string gene, bool norm)
    {
        if(i==0) File.AppendAllText(path, obj + ", " + gene + ", " + norm + ", " + System.DateTime.Now.ToString("HH:MM:ss") + "\n");

        i++;
        if (i > 18) i = 0;

    }


    public static string SentenceCase(string input)
    {
        if (input.Length < 1)
            return input;
        string sentence = input.ToLower();
        return sentence[0].ToString().ToUpper() + sentence.Substring(1);
    }
}
