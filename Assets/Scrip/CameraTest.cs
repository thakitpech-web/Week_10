using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform player;       // ตัว player
    public float mouseSensitivity = 200f;
    public float distance = 5f;    // ระยะห่างกล้อง

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // รับค่าเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        // จำกัดมุมเงย
        xRotation = Mathf.Clamp(xRotation, -40f, 80f);

        // หมุนกล้อง
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // ตำแหน่งกล้อง
        Vector3 position = player.position - (rotation * Vector3.forward * distance);

        transform.position = position;
        transform.rotation = rotation;
    }
}
