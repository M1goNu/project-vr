using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GameManager2 : MonoBehaviour
{
    [Header("Narator & Suara")]
    public AudioSource audioNarator;

    [Header("Persyaratan Menang")]
    public XRSocketInteractor[] socketMakan;
    public XRSocketInteractor[] socketDapur;
    public XRSocketInteractor[] socketSantai;

    [Header("Teks Petunjuk")]
    public TextMeshProUGUI teksMakan;
    public TextMeshProUGUI teksDapur;
    public TextMeshProUGUI teksSantai;

    [Header("UI")]
    public GameObject canvasInfo;
    public GameObject canvasMenang;
    public GameObject winScreen;

    private bool gameSelesai = false;

    void Update()
    {
        if (gameSelesai) return;
        if (audioNarator != null && audioNarator.isPlaying) return;

        UpdateTeksPetunjuk();
        CekKemenangan();
    }

    void UpdateTeksPetunjuk()
    {
        int terisiMakan = HitungTerisi(socketMakan);
        int terisiDapur = HitungTerisi(socketDapur);
        int terisiSantai = HitungTerisi(socketSantai);

        if (teksMakan != null)
            teksMakan.text = $"Taruh barang di ruang makan {terisiMakan}/{socketMakan.Length}";

        if (teksDapur != null)
            teksDapur.text = $"Taruh barang di dapur {terisiDapur}/{socketDapur.Length}";

        if (teksSantai != null)
            teksSantai.text = $"Taruh barang di ruang Santai {terisiSantai}/{socketSantai.Length}";
    }

    int HitungTerisi(XRSocketInteractor[] listSocket)
    {
        int count = 0;
        foreach (XRSocketInteractor socket in listSocket)
            if (socket.hasSelection) count++;
        return count;
    }

    void CekKemenangan()
    {
        if (ApakahSemuaTerisi(socketMakan) &&
            ApakahSemuaTerisi(socketDapur) &&
            ApakahSemuaTerisi(socketSantai))
        {
            gameSelesai = true;
            if (canvasInfo != null) canvasInfo.SetActive(false);
            if (canvasMenang != null) canvasMenang.SetActive(true);
            if (winScreen != null) winScreen.SetActive(true);
        }
    }

    bool ApakahSemuaTerisi(XRSocketInteractor[] listSocket)
    {
        if (listSocket.Length == 0) return false;
        foreach (XRSocketInteractor socket in listSocket)
            if (!socket.hasSelection) return false;
        return true;
    }
}
