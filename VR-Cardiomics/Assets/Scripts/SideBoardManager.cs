using UnityEngine;

public class SideBoardManager : MonoBehaviour
{
    public GameObject geneMenu;
    public GameObject setttingsMenu;
    public GameObject dataMenu;
    public GameObject sideBar;

    public GameObject geneMenuBtn;
    public GameObject setttingsMenuBtn;
    public GameObject dataMenuBtn;
    private bool expanded = true;
    public void activateDataSetMenu()
    {
        if (geneMenu.activeSelf) geneMenu.SetActive(false);
        if (setttingsMenu.activeSelf) setttingsMenu.SetActive(false);

        if (!dataMenu.activeSelf) dataMenu.SetActive(true);
    }

    public void activateGeneMenu()
    {
        if (dataMenu.activeSelf) dataMenu.SetActive(false);
        if (setttingsMenu.activeSelf) setttingsMenu.SetActive(false);

        if (!geneMenu.activeSelf) geneMenu.SetActive(true);
    }
    public void activateSettingsMenu()
    {
        if (geneMenu.activeSelf) geneMenu.SetActive(false);
        if (dataMenu.activeSelf) dataMenu.SetActive(false);

        if (!setttingsMenu.activeSelf) setttingsMenu.SetActive(true);
    }

    public void expandSideBar()
    {
        switch (expanded)
        {
            case (true):
                sideBar.transform.localPosition = new Vector3(17, 0, 0);
                expanded = !expanded;
                break;
            case (false):
                sideBar.transform.localPosition = new Vector3(19.5f, 0, 0);
                expanded = !expanded;
                break;
        }
    }

}
