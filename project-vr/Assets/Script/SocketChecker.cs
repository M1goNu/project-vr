using UnityEngine;
using TMPro; // Penting: Tambahkan ini untuk mengakses TextMeshPro
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketChecker : MonoBehaviour
{
    public XRSocketInteractor socket1;
    public XRSocketInteractor socket2;
    public TextMeshPro teksTray; // Referensi ke komponen teksnya

    public void CheckSockets()
    {
        int count = 0;

        // Hitung berapa botol yang sudah ditaruh
        if (socket1.hasSelection) count++;
        if (socket2.hasSelection) count++;

        // Update isi tulisan
        teksTray.text = "Taruh " + count + "/2 botol ke dalam tray untuk membuka pintu";

        // Jika sudah 2 botol, hilangkan teksnya
        if (count == 2)
        {
            teksTray.gameObject.SetActive(false);
        }
        else
        {
            teksTray.gameObject.SetActive(true);
        }
    }
}