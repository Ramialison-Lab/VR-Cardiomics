using UnityEngine;

public class SliceBehavior : MonoBehaviour
{
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    private Vector3 savePos;
    private Transform heart;
    public Vector3 original;
    public bool snapedIn =true;

    void Start()
    {
        //Store default position of GameObject
        spawnPos = this.gameObject.transform.position;
        spawnRot = this.gameObject.transform.rotation;
        original = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        heart = this.gameObject.transform.parent;
    }

    void Update()
    {
        //Control of kinematic if GameObject is not currently grabbed
        _ = this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed ? this.gameObject.GetComponent<Rigidbody>().isKinematic = false : this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if (this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            snapedIn = false;
            this.gameObject.transform.SetParent(null);
        }

    }

    public void Reset()
    {
        if (!snapedIn)
        {
            Debug.Log("hello");
           // savePos = this.gameObject.transform.position;
            this.gameObject.transform.SetParent(heart);
           // this.gameObject.transform.position = savePos;
            snapedIn = true;
        }
        // Reset position, rotation and size of each slice
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);

        this.gameObject.transform.rotation = spawnRot;
        this.gameObject.transform.localScale = original;
        snapedIn = true;
    }


    //Returns if selected object is currently grabbed
    public bool isGrabbed()
    {
        return this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed;
    }

}
