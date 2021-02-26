using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBehavior : MonoBehaviour
{
    public GameObject heart;
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    public Vector3 original;
    private Vector3 movement;

    public Transform tofollow;
    private Vector3 offset;

    void Start()
    {
        heart = GameObject.Find("Heart");
        spawnPos = this.gameObject.transform.position;
        spawnRot = this.gameObject.transform.rotation;

        offset = this.gameObject.transform.position - heart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        original = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

        _ = this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed ? this.gameObject.GetComponent<Rigidbody>().isKinematic = false : this.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        if (this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            //  movement = this.gameObject.transform.position - original;

            heart.transform.position = Vector3.Lerp(heart.transform.position, this.gameObject.transform.position - offset, 0.2f);
            heart.transform.rotation = this.gameObject.transform.rotation;

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
