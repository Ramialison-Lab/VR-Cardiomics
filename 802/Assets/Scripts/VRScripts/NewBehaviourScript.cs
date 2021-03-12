using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject sphere;
    void Update()
    {
        transform.position = sphere.transform.position;
    }
}
