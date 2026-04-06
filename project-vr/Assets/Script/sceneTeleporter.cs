using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTeleporter : MonoBehaviour
{
    public string sceneName = "environment";

    // Fungsi ini terpanggil otomatis saat objek ber-collider masuk ke area ini
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ada objek masuk ke trigger: " + other.gameObject.name);
        // Mengecek apakah yang masuk adalah Player (XR Origin)
        // Pastikan XR Origin Anda memiliki Tag "Player" atau sesuaikan di sini
        SceneManager.LoadScene(sceneName);
    }
}