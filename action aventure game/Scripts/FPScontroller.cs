using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour
{

    public GameObject cam;
    public float speed = 2f, sensitivity = 2f, jumpDistance = 5f;
    float moveFB, moveLR, rotX, rotY, verticalVelocity;
    CharacterController CharCon;
    Animator anim;
    
    void Start()
    {
        CharCon = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    void update()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        CharCon.Move(movement * Time.deltaTime);

        if (CharCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpDistance;
            }
        }
        if (CharCon.velocity.x > 0 || CharCon.velocity.z > 0 || CharCon.velocity.x < 0 || CharCon.velocity.z < 0)
        {
            anim.SetFloat("Speed", 1);
        } else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate()
    {
        if (!CharCon.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            anim.SetBool("Jump", true);
            anim.SetBool("Jump", false);
        }
        else
        {

        }
    }


}
