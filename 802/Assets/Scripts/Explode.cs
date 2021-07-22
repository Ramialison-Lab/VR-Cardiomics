using UnityEngine;
using UnityEngine.UI;

// Needed to access onscreen elements

/*****
 * 
 * 'Explodes' the heart by slices to allow the user to view each slice individually.
 * Displaces each slice an equal distance away from each other by using the transform function.
 * 
 *****/


public class Explode : MonoBehaviour
{

    public Button expandBtn;
    public Button resetBtn;
    public GameObject player;
    private bool explode = false;

    Vector3[] startPositions = new Vector3[5];
    // Position of slices at load

    public Text explodeBtnTxt;
    // 'Expand' or 'Collapse' button

    // So we can iterate over each slice
    private static string[] slices = new string[5] { "Slice_A", "Slice_B", "Slice_C", "Slice_D", "Slice_E" };

    // Whether we are currently 'exploded' (Not bool so I can use in calculations, C# is cooky about this it seems)
    int exploded = 1;

    // Record the start position for each of the slices
    void Start()
    {
        player = GameObject.Find("LocalAvatar");
        for (int i = 0; i < 5; i++)
        {
            startPositions[i] = GameObject.Find(slices[i]).transform.position;
        }

    }

    // Resets all slices back to their start positions
    public void Reset()
    {

        explodeBtnTxt.text = "Expand";
        exploded = 1;

        for (int i = 0; i < 5; i++)
        {
            GameObject.Find(slices[i]).transform.position = startPositions[i];
        }

    }

    // If the slices are exploded pull them in, or vice versa
    public void Splode()
    {
        if (GameObject.Find("HeartCopy(Clone)") != null && explode)
        {
            GameObject.Find("HeartCopy(Clone)").transform.Translate(0, 0, -1.0f);
            explode = !explode;
        }
        else if (GameObject.Find("HeartCopy(Clone)") != null && !explode)
        {
            GameObject.Find("HeartCopy(Clone)").transform.Translate(0, 0, 1.0f);
            explode = !explode;
        }

        expandBtn.interactable = false;
        resetBtn.interactable = false;

        for (int i = 0; i < 5; i++)
        {
            Vector3 next;
            Vector3 current;
            if (exploded == 1)
            {


                next = new Vector3(startPositions[i].x + (-1F * i) + 2F, startPositions[i].y, startPositions[i].z + 0.0F);

            }
            else
            {
                next = startPositions[i];
            }
            current = GameObject.Find(slices[i]).transform.position;

            System.Collections.IEnumerator sp = slide(i, next, current);
            StartCoroutine(sp);

        }

        if (exploded == 1)
        {
            explodeBtnTxt.text = "Collapse";
        }
        else
        {
            explodeBtnTxt.text = "Expand";
        }

        exploded = exploded * -1;
    }

    // Smooth glide to the finish line
    System.Collections.IEnumerator slide(int i, Vector3 next, Vector3 current)
    {

        float duration = 0.4f;

        float t = 0f;
        while (t < 1)
        {

            t += Time.deltaTime / duration;
            GameObject.Find(slices[i]).transform.position = Vector3.Lerp(current, next, t);
            yield return null;
        }

        expandBtn.interactable = true;
        resetBtn.interactable = true;
    }

}
