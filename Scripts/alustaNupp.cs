using UnityEngine;
using UnityEngine.SceneManagement; // vaja et toimiks Scene vahetus

public class alustaNupp : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("Esimene"); // Scene nimi kuhu minnakse
    }
}
