using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject sphere;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = sphere.transform.position;  
    }
}
