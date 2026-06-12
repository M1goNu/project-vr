using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class ContinuousTurnUI : MonoBehaviour
{
    [Header("Komponen Continuous Turn")]
    [SerializeField] private Toggle continuousToggle;
    [SerializeField] private ContinuousTurnProvider continuousProvider;

    void Start()
    {
        // Default: 1 (Nyala)
        bool isOn = PlayerPrefs.GetInt("ContinuousTurn_State", 1) == 1;

        if (continuousToggle != null) continuousToggle.SetIsOnWithoutNotify(isOn);
        if (continuousProvider != null) continuousProvider.enabled = isOn;

        if (continuousToggle != null)
            continuousToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool val)
    {
        if (continuousProvider != null) continuousProvider.enabled = val;
        PlayerPrefs.SetInt("ContinuousTurn_State", val ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Continuous Turn: " + val);
    }
}