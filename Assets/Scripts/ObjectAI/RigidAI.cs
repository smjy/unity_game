using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidAI : AI {

    protected Rigidbody rb;

    protected override void Awake() {
        rb = GetComponent<Rigidbody>();
        base.Awake();
    }

    public void initSpeed(Vector3 speed) {
        rb.velocity = speed;
    }

    public void initRotationSpeed(Vector3 speed) {
        rb.angularVelocity = speed;
    }
}
