using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class RotatingEffect : Effect {
    
    protected Rigidbody rb;

    [Tooltip("角速度")]public float rotate_speed = 5f;
    protected override void Start() {
        base.Start();
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = rotate_speed*Random.onUnitSphere;
    }
}