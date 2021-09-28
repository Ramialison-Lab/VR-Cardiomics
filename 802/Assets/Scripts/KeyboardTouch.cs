using UnityEngine;

public class KeyboardTouch : MonoBehaviour
{
    private Vector3 pos;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Detector")
        {

            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.collider);
        }

        if (collision.gameObject.tag == "Detector")
        {
            GameObject.FindObjectOfType<Keyboard>().touchInput(gameObject.name);

        }

    }

}
