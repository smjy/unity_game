using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StartSpeed : MonoBehaviour {
    
    Rigidbody rb;
    public Vector3 start_speed = new Vector3(0f,0f,0f);
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        rb.AddForce(start_speed,ForceMode.VelocityChange);
    }
}
