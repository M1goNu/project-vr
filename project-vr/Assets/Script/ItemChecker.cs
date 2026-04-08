using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ItemChecker : MonoBehaviour
{
    public XRSocketInteractor[] allSockets;

    public TextMeshPro teksPetunjuk;

    [Header("Pengaturan Teks")]
    public string namaItem = "buku";
    public string namaTempat = "rak";

    public void CheckSockets()
    {
        int count = 0;

        foreach (XRSocketInteractor socket in allSockets)
        {
            if (socket.hasSelection) count++;
        }

        int totalItem = allSockets.Length;

        teksPetunjuk.text = "Taruh " + count + "/" + totalItem + " " + namaItem + " di " + namaTempat;

        if (count == totalItem)
        {
            teksPetunjuk.gameObject.SetActive(false);
        }
        else
        {
            teksPetunjuk.gameObject.SetActive(true);
        }
    }
}