using Unity.XR.CoreUtils;
using UnityEngine;

public class ScCharrXROrigin : MonoBehaviour
{
    XROrigin xrori;
    [SerializeField] float fixedY = 1f;
    void Start()
    {
        xrori = this.GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 curPos = this.transform.position;
        if (curPos.y != fixedY)
        {
            this.transform.position = new Vector3(curPos.x, fixedY, curPos.z);
        }
    }
}
