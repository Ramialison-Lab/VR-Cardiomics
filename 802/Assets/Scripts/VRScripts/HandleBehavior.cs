using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBehavior : MonoBehaviour
{
    public GameObject heart;
    private Vector3 spawnPos;
    private Vector3[] savePos;
    private Quaternion spawnRot;
    public Vector3 original;
    private Vector3 movement;
    private SliceBehavior[] slices;

    void Start()
    {
        heart = GameObject.Find("Heart");
        spawnPos = this.gameObject.transform.position;
        spawnRot = this.gameObject.transform.rotation;
        slices = Object.FindObjectsOfType<SliceBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

        original = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

        _ = this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed ? this.gameObject.GetComponent<Rigidbody>().isKinematic = false : this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if (this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed)
        {

            foreach (SliceBehavior slice in slices)
            {
                if (!slice.snapedIn)
                {
                }
            }

        }
    }

    public void Reset()
    {
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);

        this.gameObject.transform.rotation = spawnRot;
        this.gameObject.transform.localScale = original;
    }

}
