using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ScreenAudioTrigger : MonoBehaviour
{
    [Header("Referensi")]
    public AudioSource audioScreen;

    private XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (interactable != null)
            interactable.activated.AddListener(_ => PlayAudio());
    }

    public void PlayAudio()
    {
        if (audioScreen == null) return;

        if (audioScreen.isPlaying)
            audioScreen.Stop();

        audioScreen.Play();
    }

    void OnDestroy()
    {
        if (interactable != null)
            interactable.activated.RemoveAllListeners();
    }
}