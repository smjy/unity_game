using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Rigidbody rb;
    float drag;
    float decrease_after;
    float life = 4f;
    Vector3 direction;

    int time;
    float speed;
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    public void Init(Vector3 d, float ss,float dg, float da, float l) {
        direction = d;
        drag = dg;
        speed = ss;
        life = l;
        decrease_after = da;

        rb.AddForce(direction*speed,ForceMode.VelocityChange);
    }
    void Start () {
   
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time++;
        if (time / 50f > decrease_after) rb.drag = drag;
        if (time / 50f > life) Destroy(gameObject);
        

   	}

   
}
