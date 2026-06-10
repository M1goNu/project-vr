using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [Header("Referensi Objek Lokal")]
    [SerializeField] private GameObject dynamicObject;

    // Variabel statis untuk mencatat scene terakhir yang benar-benar aktif sebelum pindah
    private static string lastActiveScene = "";
    private bool startedInThisScene = false;

    void Awake()
    {
        // Jika lastActiveScene masih kosong, berarti game baru pertama kali dijalankan/di-play di scene ini
        if (string.IsNullOrEmpty(lastActiveScene))
        {
            startedInThisScene = true;
            lastActiveScene = SceneManager.GetActiveScene().name;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetPositions(scene.name);

        // Perbarui scene terakhir setelah posisi selesai diatur
        lastActiveScene = scene.name;
    }

    private void SetPositions(string sceneName)
    {
        if (dynamicObject == null) return;

        if (sceneName == "Level 1 House")
        {
            dynamicObject.transform.position = new Vector3(393.12f, 100.91f, 309.74f);
            dynamicObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (sceneName == "Master-test")
        {
            // KONDISI: Jika dari awal (Play di Editor) sudah di Master-test, JANGAN ubah posisi
            if (startedInThisScene && lastActiveScene == "Master-test")
            {
                Debug.Log("Player sudah berada di Master-test sejak awal permainan. Posisi dipertahankan.");
                startedInThisScene = false; // Reset status
                return;
            }

            // Koordinat baru jika datang dari scene lain (misal dari Level 1 ke Tutorial)
            dynamicObject.transform.position = new Vector3(0f, 0f, 0f); // Ganti sesuai kebutuhan
            dynamicObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("Player pindah dari scene lain ke Master-test. Posisi diatur ke koordinat baru.");
        }
        else if (sceneName == "Level 2")
        {
            dynamicObject.transform.position = new Vector3(322.34f, 101.58f, 378.79f); // Ganti sesuai kebutuhan
            dynamicObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    // --- FUNGSI TOMBOL UI / TRIGGER PERPINDAHAN ---

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1 House");
    }

    public void GoToLevelTutorial()
    {
        SceneManager.LoadScene("Master-test");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
}