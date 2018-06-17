using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

[RequireComponent(typeof(Rigidbody))]
public class RestrictedFloatingAI : RigidAI {

    public float restricted_radius = 50f;
    public float max_speed = 20f;
    public float force = 2000f;
    public float change_time = 5f;
    public float rotate_speed = 1f; //1s能转多少度
    public float start_direction = 0f;

    int time = 50;
    float direction;
    Vector3 start_position;
    float target_direction;

    float getDistance() {
        return Vector3.Distance(transform.position,start_position);
    }
    float getDistanceRatio() {
        return Mathf.Min(1,getDistance() / restricted_radius);
    }

    protected override void Start() {
   
        base.Start();
        start_position = transform.position;
        float direction_radians;
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

        time++;
        if (time > change_time*50) {
            time = 0;
            //偏离初始点太远则回转
            Vector3 recover_direction = (start_position - transform.position).normalized;
            target_direction = fixDir(zDirDegree(recover_direction) + (1-getDistanceRatio())*Random.Range(-180f,180f));     

        }

        if (direction != target_direction) {
            float t = rotate_speed * 50f / 360f;
            //t = Easing.EaseIn(t,EasingType.Sine);
            direction = Mathf.LerpAngle(direction,target_direction,t);
            transform.eulerAngles = new Vector3(0f,0f,fixDir(direction-start_direction));
        }  

    }

    
}
