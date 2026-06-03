using UnityEngine;
using UnityEngine.UI;

public class LocomotionToggleController : MonoBehaviour
{
    [Header("Pengaturan Jenis Turn")]
    [SerializeField] private string saveKey = "SnapTurnSavedState"; // Key unik untuk PlayerPrefs
    [SerializeField] private bool defaultValue = true;            // Kondisi awal bawaan game

    [Header("Referensi Komponen Gerak XR")]
    [SerializeField] private GameObject locomotionComponent;       // Tarik komponen gerak ke sini

    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();

        if (toggle != null)
        {
            // 1. Ambil data yang tersimpan di memori lokal (1 = True, 0 = False)
            int defaultInt = defaultValue ? 1 : 0;
            bool savedState = PlayerPrefs.GetInt(saveKey, defaultInt) == 1;

            // 2. Paksa visual Toggle mengikuti data tanpa memicu event OnValueChanged
            toggle.SetIsOnWithoutNotify(savedState);

            // 3. Paksa komponen pergerakan XR aktif/mati sesuai data tersimpan
            ApplyLocomotionState(savedState);

            // 4. Daftarkan fungsi pemicu ketika player mengklik Toggle secara manual
            toggle.onValueChanged.AddListener(OnToggleClicked);
        }
    }

    private void OnToggleClicked(bool isOn)
    {
        // Simpan data baru saat diklik
        PlayerPrefs.SetInt(saveKey, isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Terapkan ke komponen pergerakan XR
        ApplyLocomotionState(isOn);
    }

    private void ApplyLocomotionState(bool isEnabled)
    {
        if (locomotionComponent != null)
        {
            locomotionComponent.SetActive(isEnabled);
            Debug.Log($"Komponen {locomotionComponent.name} diset ke: {isEnabled}");
        }
    }

    void OnDestroy()
    {
        if (toggle != null)
        {
            toggle.onValueChanged.RemoveListener(OnToggleClicked);
        }
    }
}