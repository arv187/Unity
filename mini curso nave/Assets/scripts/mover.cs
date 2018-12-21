using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {


    private Rigidbody rig;
    public float speed;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    
    void Start () {
        rig.velocity = transform.forward * speed;
	}
	
}
