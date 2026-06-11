using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class LocomotionToggleController : MonoBehaviour
{
    [Header("Pengaturan Jenis Turn")]
    [SerializeField] private string saveKey = "SnapTurnSavedState";
    [SerializeField] private bool defaultValue = true;

    [Header("Pilih Salah Satu")]
    [SerializeField] private SnapTurnProvider snapTurnProvider;
    [SerializeField] private ContinuousTurnProvider continuousTurnProvider;

    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        if (toggle == null) return;

        int defaultInt = defaultValue ? 1 : 0;
        bool savedState = PlayerPrefs.GetInt(saveKey, defaultInt) == 1;

        toggle.SetIsOnWithoutNotify(savedState);
        ApplyState(savedState);

        toggle.onValueChanged.AddListener(OnToggleClicked);
    }

    private void OnToggleClicked(bool isOn)
    {
        PlayerPrefs.SetInt(saveKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
        ApplyState(isOn);
    }

    private void ApplyState(bool isEnabled)
    {
        if (snapTurnProvider != null)
        {
            snapTurnProvider.enabled = isEnabled;
            Debug.Log($"SnapTurn diset ke: {isEnabled}");
        }

        if (continuousTurnProvider != null)
        {
            continuousTurnProvider.enabled = isEnabled;
            Debug.Log($"ContinuousTurn diset ke: {isEnabled}");
        }
    }

    void OnDestroy()
    {
        if (toggle != null)
            toggle.onValueChanged.RemoveListener(OnToggleClicked);
    }
}