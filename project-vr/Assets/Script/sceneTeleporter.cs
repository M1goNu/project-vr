using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    public string teleportscene = "Level 1 House";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pastikan Player VR Anda punya tag "Player"
        {
            SceneManager.LoadScene(teleportscene);
        }
    }
}