using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatmapCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.name == "Heart_Grabber")
            {
                GameObject.Find("ScriptHolder").GetComponent<HeatmapCompareManager>().safeToSH(this.gameObject.transform.root.gameObject);
            }       
    }

}
