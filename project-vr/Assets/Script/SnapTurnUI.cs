using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class SnapTurnUI : MonoBehaviour
{
    [Header("Komponen Snap Turn")]
    [SerializeField] private Toggle snapToggle;
    [SerializeField] private SnapTurnProvider snapProvider;

    void Start()
    {
        // Default: 1 (Nyala)
        bool isOn = PlayerPrefs.GetInt("SnapTurn_State", 1) == 1;

        if (snapToggle != null) snapToggle.SetIsOnWithoutNotify(isOn);
        if (snapProvider != null) snapProvider.enabled = isOn;

        if (snapToggle != null)
            snapToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool val)
    {
        if (snapProvider != null) snapProvider.enabled = val;
        PlayerPrefs.SetInt("SnapTurn_State", val ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Snap Turn: " + val);
    }
}