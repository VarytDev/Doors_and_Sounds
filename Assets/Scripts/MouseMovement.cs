using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private float angle;
    [SerializeField] private float minAngle = -70, maxAngle = 70;

    [SerializeField] private float mouseSensitivityX = 30;
    [SerializeField] private float mouseSensitivityY = 30;
    private Transform camT;
    private Camera cam;

    void Start()
    {
        camT = transform.GetChild(0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = camT.GetComponent<Camera>();
    }

    void OnGUI()
    {
        int size = 18;
        float posX = cam.pixelWidth/2 - size/4;
        float posY = cam.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivityX, Vector3.up);

        angle -= Input.GetAxis("Mouse Y") * mouseSensitivityY;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        float angleY = camT.localEulerAngles.y;
        camT.localEulerAngles = new Vector3(angle, angleY, 0);
    }
}
