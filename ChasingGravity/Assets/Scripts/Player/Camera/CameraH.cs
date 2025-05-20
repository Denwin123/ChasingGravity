using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/Camera/CameraH")]
public class CameraH : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("How easily the camera can look around"), Min(0), SerializeField]
    private float sensitivity = 4.5f;
    private float mouseX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Gets the mouses position if cursor is hidden
        if (!Cursor.visible)
            mouseX = Input.GetAxis("Mouse X");
        else
            mouseX = 0;

        // sets the new camera postion
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += (mouseX * sensitivity);
        transform.localEulerAngles = newRotation;
    }
}
