using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
