using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pastikan Player VR Anda punya tag "Player"
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1 House");
        }
    }
}