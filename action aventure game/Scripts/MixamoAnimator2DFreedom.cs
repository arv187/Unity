using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]


public class MixamoAnimator2DFreedom : MonoBehaviour {
    
    public Animator anim;
    public float Vertical_Raycast = 0.95f;
    public bool EnSuelo = true;

    bool isWalking = false;

    const float WALK_SPEED = .3f;
    
    void Awake()
    {
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        Walking();//walking
        Turning();//turning
        Jump();//jumping        
        Move();//move
    }

    void Turning()
    {
        anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }
    void Walking()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) { //when is pressed toggle beetween walk/run (to machine state)
           isWalking = !isWalking;
            anim.SetBool("Walk", isWalking);
        }               
    }

    internal void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    void Move()
    {
        //anim.SetFloat("Forward", Input.GetAxis("Vertical")); //Move_animatorParameter_"Fordward"

        /* Walk Toggle - We will need to change this to account for the lerping
         * keep a toogle in Mecanim as well.
         */

        if (anim.GetBool("Walk"))
        {
            anim.SetFloat("MoveZ", Mathf.Clamp(Input.GetAxis("MoveZ"), -WALK_SPEED,WALK_SPEED));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED,WALK_SPEED));             
        }
        else
        {
            anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
            anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&EnSuelo)
            anim.SetTrigger("Jump");
        RaycastHit get_ground;
        Vector3 physicsCenter = this.transform.position + this.GetComponent<CapsuleCollider>().center;
        Debug.DrawRay(physicsCenter, Vector3.down * Vertical_Raycast, Color.green, 1);
        if (Physics.Raycast(physicsCenter, Vector3.down, out get_ground, Vertical_Raycast))

        {
            if (get_ground.transform.gameObject.tag != "Player")
            {
                EnSuelo = true;
            }
        }
        else
        {
            EnSuelo = false;
        }
        Debug.Log(EnSuelo);
        }
        
    }
