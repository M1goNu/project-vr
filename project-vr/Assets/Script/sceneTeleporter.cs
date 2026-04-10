using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [Header("Referensi")]
    public GameObject dynamicObject;

    private static SceneTeleporter instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Menjaga script ini tetap hidup

        if (dynamicObject != null)
        {
            DontDestroyOnLoad(dynamicObject);
        }
    }

    private void OnEnable()
    {
        // Mendaftarkan fungsi pindah posisi ke sistem Scene Manager
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Fungsi ini dipanggil OTOMATIS tepat setelah scene baru muncul
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1 House")
        {
            SetPositions();
        }
    }

    void SetPositions()
    {
        // 1. Set posisi Dynamic (Berdasarkan Gambar 1)
        if (dynamicObject != null)
        {
            dynamicObject.transform.position = new Vector3(399.79f, 90.08f, 299.64f);
            dynamicObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1 House");
    }
}