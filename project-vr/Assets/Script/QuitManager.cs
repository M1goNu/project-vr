using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public void KeluarGame()
    {
        Debug.Log("Mencoba keluar dari game..."); // Sebagai penanda di Console

        #if UNITY_EDITOR
            // Jika kita sedang mengetes di dalam Unity Editor, ini akan mematikan mode Play
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Jika game sudah di-build (APK/EXE), ini akan benar-benar menutup aplikasi
            Application.Quit();
        #endif
    }
}