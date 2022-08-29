using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerT;
    [SerializeField] float mouseSensitivity = 100f;
    float rotation;

    void Start()
    {
        if (playerT == null && transform.parent.transform != null)
            playerT = transform.parent.transform;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        playerT.Rotate(Vector3.up, mouseX);
    }
}
