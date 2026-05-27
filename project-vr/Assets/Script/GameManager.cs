using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GameManager : MonoBehaviour
{
    [Header("Narator & Suara")]
    public AudioSource audioNarator;

    [Header("Pengaturan Timer")]
    public TextMeshPro teksTimer;
    public float totalWaktu = 300f;
    private bool gameSelesai = false;

    [Header("Persyaratan Menang")]
    public XRSocketInteractor[] socketBuku;
    public XRSocketInteractor[] socketMainan;
    public XRSocketInteractor[] socketTopi;

    [Header("UI Kemenangan")]
    public GameObject tombolQuit;
    public GameObject tombolPlayAgain;
    public GameObject tombolNextLevel;

    void Update()
    {
        if (gameSelesai) return;

        if (audioNarator != null && audioNarator.isPlaying)
        {
            return;
        }

        if (totalWaktu > 0)
        {
            totalWaktu -= Time.deltaTime;
            UpdateTeksTimer(totalWaktu);
            CekKemenangan();
        }
        else
        {
            totalWaktu = 0;
            gameSelesai = true;
            teksTimer.text = "WAKTU HABIS! Anda Gagal!";
            teksTimer.color = Color.red;

            if (tombolQuit != null) tombolQuit.SetActive(true);
            if (tombolPlayAgain != null) tombolPlayAgain.SetActive(true);
            if (tombolNextLevel != null) tombolNextLevel.SetActive(true);
        }
    }

    void UpdateTeksTimer(float waktuSisa)
    {
        float menit = Mathf.FloorToInt(waktuSisa / 60);
        float detik = Mathf.FloorToInt(waktuSisa % 60);
        teksTimer.text = string.Format("{0:00}:{1:00}", menit, detik);
    }

    void CekKemenangan()
    {
        if (ApakahSemuaTerisi(socketBuku) && ApakahSemuaTerisi(socketMainan) && ApakahSemuaTerisi(socketTopi))
        {
            gameSelesai = true;
            teksTimer.text = "ESCAPE SUCCESS!";
            teksTimer.color = Color.green;

            if (tombolQuit != null) tombolQuit.SetActive(true);
            if (tombolPlayAgain != null) tombolPlayAgain.SetActive(true);
            if (tombolNextLevel != null) tombolNextLevel.SetActive(true);
        }
    }

    bool ApakahSemuaTerisi(XRSocketInteractor[] listSocket)
    {
        if (listSocket.Length == 0) return false;

        foreach (XRSocketInteractor socket in listSocket)
        {
            if (!socket.hasSelection)
            {
                return false;
            }
        }
        return true;
    }
}