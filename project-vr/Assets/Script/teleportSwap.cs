using UnityEngine;

public class TeleportSwap : MonoBehaviour
{
    public GameObject playerVR;    // Isi dengan XR Origin (VR)
    public GameObject dummyObject;

    public void SwapPosition()
    {
        if (playerVR == null || dummyObject == null) return;

        // Ambil komponen Character Controller jika ada
        CharacterController cc = playerVR.GetComponent<CharacterController>();

        // 1. Simpan posisi dummy & player saat ini
        Vector3 playerPosBefore = playerVR.transform.position;
        Vector3 dummyPosBefore = dummyObject.transform.position;

        // 2. Matikan CC agar posisi bisa dipindahkan paksa
        if (cc != null) cc.enabled = false;

        // 3. TUKAR POSISI
        playerVR.transform.position = dummyPosBefore;
        dummyObject.transform.position = playerPosBefore;

        // 4. Hidupkan kembali CC
        if (cc != null) cc.enabled = true;

        Debug.Log("Posisi Berhasil Ditukar!");
    }
}