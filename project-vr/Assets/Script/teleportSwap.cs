using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class teleportSwap : MonoBehaviour
{
    public GameObject playerVR; // Isi dengan XR Origin (VR)
    public GameObject dummyObject; // Isi dengan HumanDummy_F White

    // Fungsi ini akan dipanggil saat teleportasi terjadi
    public void SwapPosition()
    {
        // 1. Simpan posisi player saat ini (sebelum pindah)
        Vector3 playerLastPos = playerVR.transform.position;

        // 2. Karena script ini menempel di Dummy, posisinya adalah target
        Vector3 dummyPos = dummyObject.transform.position;

        // 3. Pindahkan Dummy ke posisi terakhir player
        dummyObject.transform.position = playerLastPos;

        // Catatan: Anda tidak perlu memindahkan Player secara manual lewat script 
        // karena komponen Teleportation Area yang akan melakukannya.
    }
}
