using UnityEngine;

public class LocomotionManager : MonoBehaviour
{
    [Header("Referensi Komponen Gerak")]
    public GameObject snapTurnComponent;
    public GameObject continuousTurnComponent;

    void Start()
    {
        // Ambil data yang tersimpan di PlayerPrefs
        bool isSnapTurnOn = PlayerPrefs.GetInt("SnapTurnSavedState", 1) == 1;

        // Terapkan kecocokan sistem gerak saat level dimulai
        if (snapTurnComponent != null)
            snapTurnComponent.SetActive(isSnapTurnOn);

        if (continuousTurnComponent != null)
            continuousTurnComponent.SetActive(!isSnapTurnOn);
    }
}