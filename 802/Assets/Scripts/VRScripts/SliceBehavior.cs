using UnityEngine;

public class SliceBehavior : MonoBehaviour
{
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    public Vector3 original;
    private bool grabbed;

    void Start()
    {
        //Store default position of GameObject
        spawnPos = this.gameObject.transform.position;
        spawnRot = this.gameObject.transform.rotation;
        original = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }

    void Update()
    {
        //Control of kinematic if GameObject is not currently grabbed
        _ = this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed ? this.gameObject.GetComponent<Rigidbody>().isKinematic = false : this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }
    public void Reset()
    {
        // Reset position, rotation and size of each slice
        this.gameObject.transform.position = spawnPos;
        this.gameObject.transform.rotation = spawnRot;
        this.gameObject.transform.localScale = original; 
    }

    //Returns if selected object is currently grabbed
    public bool isGrabbed()
    {
        grabbed = this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed;
        return grabbed;
    }
}
