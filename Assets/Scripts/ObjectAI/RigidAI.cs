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

    //辅助函数
    protected Vector3 zEuler(float dir) {
        return new Vector3(Mathf.Cos(dir),Mathf.Sin(dir),0);
    }
    protected Vector3 zEulerDegree(float dir) {
        return zEuler(dir*Mathf.Deg2Rad);
    }
    protected float zDir(Vector3 euler) {
        if (euler.y > 0) return Mathf.Acos(euler.x);
        if (euler.y == 0) return euler.x > 0 ? 0f : Mathf.PI;
        return -Mathf.Acos(euler.x);
    }
    protected float zDirDegree(Vector3 euler) {
        return zDir(euler)*Mathf.Rad2Deg;
    }
    protected float fixDir(float dir) {
        if (dir < 0) return dir + 360f;
        if (dir > 360f) return dir - 360f;
        return dir;
    }
}
