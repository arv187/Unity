//My canibalized script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(MixamoAnimator2DFreedom))]

public class MouseCam : MonoBehaviour
{

    public GameObject cam;
    public float speed = 2f, sensitivity = 2f;
    float moveFB, moveLR, rotX, rotY, verticalVelocity;
    MixamoAnimator2DFreedom CharCon; //require the MixammoAnimator2DFreedom script

    void Start()
    {
        CharCon = gameObject.GetComponent<MixamoAnimator2DFreedom>();
    }

    void Update()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -50f, 50f);

        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        CharCon.Move(movement * Time.deltaTime);

    }
}