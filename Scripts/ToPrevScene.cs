using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPrevScene : MonoBehaviour
{
    private int prevSceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Esimene");
    }
}
