using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float LookSensitivity = 1f;
    public float LookSmoothDamp = .5f;

    [HideInInspector]
    public float XRotation;

    [HideInInspector]
    public float YRotation;

    [HideInInspector]
    public float CurrentY;

    [HideInInspector]
    public float CurrentX;

    [HideInInspector]
    public float YRotationVertical;

    [HideInInspector]
    public float XRotationVertical;

    private bool lockCamera;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void LateUpdate()
    {
        var xAxis = Input.GetAxisRaw("Mouse X") * LookSensitivity;
        var yAxis = Input.GetAxisRaw("Mouse Y") * LookSensitivity;

        if (!lockCamera)
        {
            YRotation += xAxis;
            XRotation += yAxis;
        }

        CurrentX = Mathf.SmoothDamp(CurrentX, XRotation, ref XRotationVertical, LookSmoothDamp);
        CurrentY = Mathf.SmoothDamp(CurrentY, YRotation, ref YRotationVertical, LookSmoothDamp);

        XRotation = Mathf.Clamp(XRotation, -150, 50);

        transform.rotation = Quaternion.Euler(-CurrentX, CurrentY, 0);
    }
}
