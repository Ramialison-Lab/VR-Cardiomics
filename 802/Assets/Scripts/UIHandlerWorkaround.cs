using UnityEngine;

public class UIHandlerWorkaround : MonoBehaviour
{
    public GameObject sphere;
    void Update()
    {
        transform.position = sphere.transform.position;
    }
}
