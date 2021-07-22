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
    private InputField geneInput;
    private void Start()
    {
        geneInput = GameObject.Find("InputGene").GetComponentInChildren<InputField>();
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
            File.AppendAllText(path, "-----\t\t\t\t" + gene + "\t\t\t\t" + System.DateTime.Now.ToString("HH:MM:ss") + "\n");

        }
        if (!save && !copy)
        {
            //both are original 
            File.AppendAllText(path, "\t\t\t\t------- \t\t\t\t" + System.DateTime.Now.ToString("HH:MM:ss") + "\n");
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

    public void exportGenelist(string str)
    {
        if (!genelist)
        {
            genelistpath = Application.dataPath + "/SimilarGeneList.txt";
            File.WriteAllText(genelistpath, "Similar Genes compared to: " + SentenceCase(geneInput.text) + " \n\n" + System.DateTime.Now + "\n \n");
            File.AppendAllText(genelistpath, "*********************************************************\n\n");
            genelist = true;
        }

        if (genelist)
        {
            if (toggle) File.AppendAllText(genelistpath, SentenceCase(str) + " \t\t");
            if (!toggle) File.AppendAllText(genelistpath, str + " \n");
            toggle = !toggle;
        }


    }
    public static string SentenceCase(string input)
    {
        if (input.Length < 1)
            return input;
        string sentence = input.ToLower();
        return sentence[0].ToString().ToUpper() + sentence.Substring(1);
    }
}
