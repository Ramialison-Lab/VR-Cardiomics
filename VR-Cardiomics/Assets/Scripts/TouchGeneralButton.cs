using UnityEngine;
using UnityEngine.UI;

public class TouchGeneralButton : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Detector")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.collider);
        }
        if (collision.gameObject.tag == "Detector")
        {
            if (gameObject.name == "InputField") { GameObject.Find("ScriptHolder").GetComponent<InputControl>().enableKeyboard(); }
            else
            {

                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }

    }

}
