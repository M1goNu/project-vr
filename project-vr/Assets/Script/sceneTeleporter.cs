using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    [Header("Referensi")]
    public GameObject dynamicObject;

    private static SceneTeleporter instance;

    // Variabel baru untuk mencatat nama scene sebelum perpindahan terjadi
    private string previousSceneName = "";

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

        // Catat scene pertama kali game dinyalakan/skrip ini aktif
        previousSceneName = SceneManager.GetActiveScene().name;
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
        // Mengecek apakah scene yang dimuat adalah salah satu dari 3 level ini
        if (scene.name == "Level 1 House" || scene.name == "Master-test" || scene.name == "Level 2")
        {
            SetPositions(scene.name);
        }

        // SETELAH posisi diatur, perbarui previousSceneName dengan scene yang saat ini aktif
        previousSceneName = scene.name;
    }

    void SetPositions(string sceneName)
    {
        if (dynamicObject == null) return;

        // Atur posisi berdasarkan nama scene yang sedang aktif
        if (sceneName == "Level 1 House")
        {
            dynamicObject.transform.position = new Vector3(398.8f, 104.79f, 313.8f);
            dynamicObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (sceneName == "Master-test")
        {
            // KONDISI BARU: Hanya ubah posisi JIKA scene sebelumnya BUKAN "Master-test"
            if (previousSceneName != "Master-test")
            {
                dynamicObject.transform.position = new Vector3(0f, 0f, 0f); // Ganti koordinat sesuai kebutuhan
                dynamicObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log("Player pindah dari scene lain ke Tutorial. Posisi diatur ulang.");
            }
            else
            {
                Debug.Log("Player sudah berada di Tutorial sejak awal. Posisi TIDAK diubah.");
            }
        }
        else if (sceneName == "Level 2")
        {
            dynamicObject.transform.position = new Vector3(317.9f, 104f, 385.4f); // Ganti koordinat sesuai kebutuhan
            dynamicObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

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