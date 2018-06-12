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

    protected virtual void initSpeed(Vector3 speed) {
        rb.velocity = speed;
    }

    protected virtual void initRotationSpeed(Vector3 speed) {
        rb.angularVelocity = speed;
    }
}
