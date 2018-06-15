using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleFloatingAI : RigidAI {

    public float max_speed = 10f;
    public float force = 2f;
    public bool one_way = false;
    public float one_way_direction = 0f;
    public float change_time = 5f;

    int time = 50;
    float direction_time = 1f;
    Vector3 direction;
    Vector3 target_direction;
    Vector3 old_direction;
    protected override void Start() {
        base.Start();
        float direction_radians;
        if (one_way) 
            direction_radians = one_way_direction * Mathf.PI / 180f;
        else 
            direction_radians = Random.Range(0f,Mathf.PI*2);

        direction = new Vector3(Mathf.Cos(direction_radians),Mathf.Sin(direction_radians),0);
        target_direction = direction;
        old_direction = direction;
    }


    protected override void FixedUpdate() {
        rb.AddForce(force*direction);
        float drag = force / (max_speed*max_speed);
        float v = rb.velocity.magnitude;
        Vector3 drag_force = (-rb.velocity).normalized*v*v*drag;
        rb.AddForce(drag_force);

        if (!one_way) {

            time++;
            if (time > change_time*50) {
                time = 0;
                old_direction = direction;
                float new_direction_radians = Random.Range(0f,Mathf.PI*2);          
                target_direction = new Vector3(Mathf.Cos(new_direction_radians),Mathf.Sin(new_direction_radians),0);
            }

            if (time < direction_time * 50) 
                direction = Vector3.Slerp(old_direction,target_direction,time/(direction_time*50));
            }
        }
        

        

    
}
