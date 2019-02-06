using UnityEngine;
using UnityEngine.SceneManagement;

public class Lõpp : MonoBehaviour
{
    private int nextSceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Lõpp");
    }
}
