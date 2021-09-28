using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class StoreDataManager : MonoBehaviour
{
    public Hashtable currentData = new Hashtable();
    public string geneName = "";
    public bool norm = true;
    public bool doublePush = false;
    int i = 0;

    private void Start()
    {
        norm = true;
    }

    public void addData(string heartpiece, string expressionValue)
    {

        i++;
        if(i >18)
        {
            i = 0;
            clearTable();
            doublePush = false;
        }
        if (!doublePush) currentData.Add(heartpiece, expressionValue);
        
    }

    public void addName(string geneName)
    {

        if (this.geneName == geneName) doublePush = true;
        this.geneName = geneName;
        setLabel(geneName);
    }

    private void setLabel(string str)
    {
        if (norm)
        {
            //TBD set text to norm
            gameObject.transform.GetChild(0).Find("Extensions").Find("NormText").GetComponentInChildren<Text>().text = "";

        }
        else
        {           
            //TBD set text to absolute
            gameObject.transform.GetChild(0).Find("Extensions").Find("NormText").GetComponentInChildren<Text>().text = "";
        }

        gameObject.transform.GetChild(0).Find("Extensions").Find("GeneOrigName").GetComponentInChildren<Text>().text = str;
    }

    public void customLabel(string str)
    {
        gameObject.transform.GetChild(0).Find("Extensions").Find("GeneOrigName").GetComponentInChildren<Text>().text = str;

    }
    public void clearTable()
    {
        currentData.Clear();
    }

    public Hashtable getDataTable()
    {
        return currentData;
    }

    public string getCurrentGene()
    {
        return this.geneName;
    }

    public void setNorm(bool norm)
    {
        this.norm = norm;
    }

}
