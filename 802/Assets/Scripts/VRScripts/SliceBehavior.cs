using UnityEngine;

public class SliceBehavior : MonoBehaviour
{
    private Quaternion spawnRot;
    private Transform heart;
    public Vector3 original;
    private Vector3 spawnPos;
    public bool snapedIn = true;
    public bool copy = false;
    public bool selected;

    void Start()
    {
        spawnPos = transform.position;
        spawnRot = transform.rotation;
        original = transform.localScale;
        heart = transform.parent;
    }
    void Update()
    {
        //Control of kinematic if GameObject is not currently grabbed
        _ = transform.GetComponent<OVRGrabbable>().isGrabbed ? GetComponent<Rigidbody>().isKinematic = false : GetComponent<Rigidbody>().isKinematic = true;
        if (transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (transform.parent.parent.name != null)
            {
                if (transform.parent.parent.name == "HeartCopy(Clone)") copy = true;
            }
            snapedIn = false;
            transform.SetParent(null);
        }
    }
    public void Reset()
    {
        if (!snapedIn)
        {
            transform.SetParent(heart);
            snapedIn = true;
        }
        // Reset position, rotation and size of each slice
        transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        transform.rotation = spawnRot;
        transform.localScale = original;
        snapedIn = true;
    }
    public bool isGrabbed()
    {
        return transform.GetComponent<OVRGrabbable>().isGrabbed;
    }
    public void instantiateSlices()
    {        //Store default position of GameObject
        spawnPos = transform.position;
        spawnRot = transform.rotation;
        original = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        heart = transform.parent;

    }
    public void selfDestruct()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision col)
    {
        selected = true;
    }
    private void OnCollisionExit(Collision col)
    {
        selected = false;
    }

}
