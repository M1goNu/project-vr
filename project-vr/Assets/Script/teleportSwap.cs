using UnityEngine;

public class TeleportSwap : MonoBehaviour
{
    public GameObject playerVR; // Referensi ke XR Origin
    public GameObject dummyObject; // Referensi ke HumanDummy

    public void SwapPositions()
    {
        if (playerVR != null && dummyObject != null)
        {
            // 1. Simpan data posisi lama untuk Dummy
            // Mengambil posisi kamera HMD saat ini untuk ditaruh ke lantai
            Vector3 oldPlayerFloorPos = new Vector3(
                Camera.main.transform.position.x,
                0,
                Camera.main.transform.position.z
            );

            // 2. Simpan data posisi lama Dummy untuk Player
            Vector3 targetPosition = dummyObject.transform.position;
            Quaternion targetRotation = dummyObject.transform.rotation;

            // 3. Pindahkan Dummy ke tempat Player berdiri sebelumnya
            dummyObject.transform.position = oldPlayerFloorPos;

            // 4. Pindahkan Player agar KAMERA berada tepat di posisi Dummy
            // Kita hitung offset antara posisi Origin dan posisi Kamera saat ini
            Vector3 cameraOffset = playerVR.transform.position - Camera.main.transform.position;
            cameraOffset.y = 0; // Abaikan tinggi agar Origin tidak amblas ke lantai

            // Set posisi Origin = Posisi Dummy + Offset Kamera
            playerVR.transform.position = targetPosition + cameraOffset;

            // Set rotasi agar menghadap ke arah yang sama dengan Dummy
            playerVR.transform.rotation = targetRotation;

            Debug.Log("Swap Presisi: Kamera Player sekarang tepat di posisi Dummy sebelumnya.");
        }
    }
}