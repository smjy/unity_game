using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

[RequireComponent(typeof(Rigidbody))]
public class CycleFollowAI : RigidAI {

    //跟随目标 一段时间后才旋转 （较少使用）

    public Transform following;
    public float nofollow_distance = 10f; //接近多远就不再跟随而是停止
    public float max_speed = 10f;
    public float force = 2f;
    public float change_time = 5f;
    public float rotate_speed = 1f; //1s能转多少度
    public float start_direction = 0f;

    int time = 50;
    float direction;
    float target_direction;


    public void setFollowing(Transform t) {
        following = t;
    }
    public void setFollowing(GameObject g) {
        following = g.transform;
    }
    float followDistance() {
        return Vector3.Distance(transform.position,following.position);
    }
    bool isFollowing() {
        return followDistance() > nofollow_distance;
    }
    
    protected override void Start() {

       
        base.Start();
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

        if (isFollowing()) {
            Vector3 direction_vector = zEulerDegree(direction);
            rb.AddForce(force*direction_vector);
        }

        float drag = force / (max_speed*max_speed);
        float v = rb.velocity.magnitude;
        Vector3 drag_force = (-rb.velocity).normalized*v*v*drag;
        rb.AddForce(drag_force);

        time++;

        
        if (time > change_time*50) {
            time = 0;
            target_direction = fixDir(zDirDegree((following.position - transform.position).normalized));
        }

        if (direction != target_direction) {
            float t = rotate_speed * 50f / 360f;
            //t = Easing.EaseIn(t,EasingType.Sine);
            direction = Mathf.LerpAngle(direction,target_direction,t);
            transform.eulerAngles = new Vector3(0f,0f,fixDir(direction-start_direction));
        }

    }
}
