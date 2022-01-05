using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileUploadManager : MonoBehaviour
{

    public GameObject filePrefab;
    private GameObject files;
    private int numberFiles = -2;
    public GameObject canvas;
    private string path = "Assets/Resources";
    private string nameFile;
    private int y = 50;
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.*");

        foreach (FileInfo f in info)
        {

            if (f.ToString().Contains("txt"))
            {
                if (!f.ToString().Contains(".meta"))
                {
                    nameFile = f.ToString();
                    nameFile = nameFile.Substring(nameFile.IndexOf("\\Resources"));
                    nameFile = nameFile.Substring(11);
                    nameFile = nameFile.Remove(nameFile.Length - 4);

                    Debug.Log(nameFile);

                    if (nameFile != "valid_names" ) if (nameFile != "GENE-DESCRIPTION-TSV_MGI_9.tsv")
                    {
                        numberFiles++;
                        
                        
                        files = Instantiate(filePrefab, canvas.transform);
                            Debug.Log(numberFiles);

                            if(numberFiles == 4) { numberFiles = -1; y = -250;}
                            files.transform.localPosition = new Vector3(150 * numberFiles - 150, y, 0);
                            
            
                            files.GetComponentInChildren<Text>().text = nameFile;
                      
                    }
                }

            }
        }

    }

}
