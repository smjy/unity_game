using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

[RequireComponent(typeof(Rigidbody))]
public class ContinuousFollowAI : RigidAI {

    //持续跟随目标

    public Transform following;
    public float nofollow_distance = 10f; //接近多远就不再跟随而是停止
    public float max_speed = 10f;
    public float force = 2f;
    public float start_direction = 0f;

    float direction;

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

    }

    float getDirection() {
        return fixDir(transform.eulerAngles.z + start_direction);
    }
    protected override void FixedUpdate() {

        direction = fixDir(zDirDegree((following.position - transform.position).normalized));

        if (isFollowing()) {
            Vector3 direction_vector = zEulerDegree(direction);
            rb.AddForce(force*direction_vector);
        }

        float drag = force / (max_speed*max_speed);
        float v = rb.velocity.magnitude;
        Vector3 drag_force = (-rb.velocity).normalized*v*v*drag;
        rb.AddForce(drag_force);


        transform.eulerAngles = new Vector3(0f,0f,fixDir(direction-start_direction));   

    }
}
