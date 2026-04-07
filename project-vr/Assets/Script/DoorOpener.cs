using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private int itemsInPlace = 0;
    private const int requiredItems = 2; // Jumlah item yang dibutuhkan
    private bool isDoorOpen = false;

    // Fungsi ini dipanggil saat benda masuk ke socket
    public void ItemPlaced()
    {
        itemsInPlace++;
        CheckConditions();
    }

    // Fungsi ini dipanggil saat benda diambil dari socket
    public void ItemRemoved()
    {
        itemsInPlace--;

        if (itemsInPlace < requiredItems && isDoorOpen)
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        door.transform.localEulerAngles = new Vector3(0, 0, 0); // Kembali ke posisi semula
        isDoorOpen = false;
        Debug.Log("Item diambil, pintu tertutup.");
    }

    private void CheckConditions()
    {
        if (itemsInPlace >= requiredItems && !isDoorOpen)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        door.transform.localEulerAngles = new Vector3(0, -90, 0);
        isDoorOpen = true;
        Debug.Log("Kedua item sudah ada. Pintu terbuka!");
    }   
}
