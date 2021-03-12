using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBehavior : MonoBehaviour
{
    private Vector3 spawnPos;
    private Vector3[] savePos;
    public Vector3 original;
    private Vector3 movement;
    private Quaternion spawnRot;
    public GameObject sphere;
    public GameObject heart;

    void Start()
    {
        heart = GameObject.Find("Heart");
        spawnPos = transform.position;
        spawnRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        original = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _ = transform.GetComponent<OVRGrabbable>().isGrabbed ? GetComponent<Rigidbody>().isKinematic = false : GetComponent<Rigidbody>().isKinematic = true;
        if (transform.GetComponent<OVRGrabbable>().isGrabbed) sphere.SetActive(false);
        if (!transform.GetComponent<OVRGrabbable>().isGrabbed) sphere.SetActive(true);
    }

    public void Reset()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        transform.position = Vector3.Lerp(gameObject.transform.position, spawnPos, 0.2f);
        transform.rotation = spawnRot;
        transform.localScale = original;
    }

    public bool isGrabbed()
    {
        return transform.GetComponent<OVRGrabbable>().isGrabbed;
    }

}
