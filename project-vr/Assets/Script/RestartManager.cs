using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void UlangiGame()
    {
        Debug.Log("Mengulang Game...");
        Scene sceneSekarang = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneSekarang.name);
    }
}