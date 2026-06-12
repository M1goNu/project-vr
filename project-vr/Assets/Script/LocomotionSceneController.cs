using UnityEngine;

public class LocomotionSceneController : MonoBehaviour
{
    [Header("Referensi Menu UI")]
    [SerializeField] private GameObject welcomeBackground; // Seret objek Welcome_Background ke sini

    [Header("Referensi Komponen Gerak XR")]
    [SerializeField] private GameObject snapTurnComponent;
    [SerializeField] private GameObject continuousTurnComponent;

    void Awake()
    {
        // Jalankan pengecekan kondisi locomotion saat scene dimulai
        EvaluateLocomotionState();
    }

    void Update()
    {
        // Opsional: Jika menu ditutup lewat tombol lain, skrip akan otomatis menyalakan locomotion
        if (welcomeBackground != null && !welcomeBackground.activeSelf)
        {
            ApplySavedLocomotion();
            enabled = false; // Matikan Update() jika sudah diterapkan agar hemat performa
        }
    }

    public void EvaluateLocomotionState()
    {
        // KONDISI UTAMA: Jika menu Welcome masih terbuka, matikan kedua locomotion!
        if (welcomeBackground != null && welcomeBackground.activeSelf)
        {
            if (snapTurnComponent != null) snapTurnComponent.SetActive(false);
            if (continuousTurnComponent != null) continuousTurnComponent.SetActive(false);
            Debug.Log("Menu Welcome aktif. Locomotion dimatikan untuk sementara.");
        }
        else
        {
            // Jika menu Welcome tidak ada atau sudah tertutup, gunakan pengaturan PlayerPrefs
            ApplySavedLocomotion();
        }
    }

    private void ApplySavedLocomotion()
    {
        // Ambil data pilihan dari PlayerPrefs (1 = True, 1 = True)
        bool isSnapTurnOn = PlayerPrefs.GetInt("SnapTurnSavedState", 1) == 1;
        bool isContinuousTurnOn = PlayerPrefs.GetInt("ContinuousTurnSavedState", 1) == 1;

        if (snapTurnComponent != null)
            snapTurnComponent.SetActive(isSnapTurnOn);

        if (continuousTurnComponent != null)
            continuousTurnComponent.SetActive(isContinuousTurnOn);

        Debug.Log($"Locomotion diterapkan. Snap: {isSnapTurnOn}, Continuous: {isContinuousTurnOn}");
    }

    // Fungsi yang bisa dipanggil oleh Tombol "Mulai/Close" di Welcome Background
    public void OnCloseWelcomeMenu()
    {
        if (welcomeBackground != null)
        {
            welcomeBackground.SetActive(false);
        }
        ApplySavedLocomotion(); // Nyalakan locomotion setelah menu ditutup
    }
}