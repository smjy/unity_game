using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

[RequireComponent(typeof(Rigidbody))]
public class SimpleFloatingAI : RigidAI {

    public float max_speed = 10f;
    public float force = 2f;
    public bool one_way = false;
    public float one_way_direction = 0f;
    public float change_time = 5f;
    public float rotate_speed = 1f; //1s能转多少度
    public float start_direction = 0f;

    int time = 50;
    float direction;
    float target_direction;

    protected override void Start() {

       
        base.Start();
        float direction_radians;
        if (one_way) 
            direction_radians = one_way_direction * Mathf.PI / 180f;
        else 
            direction_radians = Random.Range(0f,Mathf.PI*2);

        direction = direction_radians * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,fixDir(direction-start_direction));
        target_direction = direction;

    }

    float getDirection() {
        return fixDir(transform.eulerAngles.z + start_direction);
    }
    protected override void FixedUpdate() {
        direction = getDirection();
        Vector3 direction_vector = zEulerDegree(direction);
        rb.AddForce(force*direction_vector);
        float drag = force / (max_speed*max_speed);
        float v = rb.velocity.magnitude;
        Vector3 drag_force = (-rb.velocity).normalized*v*v*drag;
        rb.AddForce(drag_force);

        if (!one_way) {

            time++;
            if (time > change_time*50) {
                time = 0;
                target_direction = Random.Range(0f,360f);     
            }

            if (direction != target_direction) {
                float t = rotate_speed * 50f / 360f;
                //t = Easing.EaseIn(t,EasingType.Sine);
                direction = Mathf.LerpAngle(direction,target_direction,t);
                transform.eulerAngles = new Vector3(0f,0f,fixDir(direction-start_direction));
            }
            
            
        }
        

    }

    
}
