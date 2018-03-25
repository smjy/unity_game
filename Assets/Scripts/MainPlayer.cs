using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainPlayer : NetworkBehaviour {
    // Use this for initialization
    public static MainPlayer me;
    public float force = 100f;
    
    public float maxSpeed = 500f;
    public float friction_extra = 20f;
    float friction;
    Rigidbody rb;

	void Start () {
        me = this;
        transform.position = new Vector3(0, 0, 100);
        friction = (force- friction_extra) / (maxSpeed * maxSpeed);
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    [Command]
    void CmdMove(Vector3 mv)
    {
        Vector3 vn = mv.normalized;
        Vector3 vm = -rb.velocity.normalized;
        float vv = rb.velocity.magnitude;
        if (mv.magnitude > 0.1) rb.AddForce(vn * force);
        if (vv > 0.1f) rb.AddForce(vm * (friction * vv * vv+ friction_extra));
    }
	void FixedUpdate () {
        if (isLocalPlayer)
        {
            Vector3 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            CmdMove(v);
        }
        
    }
}
