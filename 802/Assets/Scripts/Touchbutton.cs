
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Touchbutton : MonoBehaviour
{
    private GameObject SH;
    private UploadFileLog uploadfilelog;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Detector")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.collider);
        }

        if (collision.gameObject.tag == "Detector")
        {
            uploadfilelog = GameObject.Find("ScriptHolder").GetComponent<UploadFileLog>();

            uploadfilelog.overWriteName(this.gameObject.GetComponentInChildren<Text>().text);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

}
