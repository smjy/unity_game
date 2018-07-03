using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

[RequireComponent(typeof(Rigidbody))]
public class StoryGuideAI : RigidAI {

    public int status = 0;
    //status 0 飞来 1 不动 2 飞走
    public TextMesh say_text;
    [HideInInspector] public Vector3 target_pos;
    [HideInInspector] public Vector3 out_pos;
    [HideInInspector] public bool look_around;
    public float nofollow_distance = 30f; //接近多远就不再跟随而是停止

    public float max_speed = 20f;
    public float force = 2000f;
    public float start_direction = 0f;

    float direction;
    Vector3 start_position;
    float recorded_direction;
    float target_direction;
    int time = 0;
    float followDistance() {
        return Vector3.Distance(transform.position,target_pos);
    }
    bool getInPos() {
        return followDistance() < nofollow_distance;
    }
    protected override void Start() {
        base.Start();
    }
    float getDirection() {
        return fixDir(transform.eulerAngles.z + start_direction);
    }

    public void say(string str) {
        Vector3 init_pos = transform.position;
        init_pos.x += 6f;
        init_pos.y += 9f;
        TextMesh tm = Instantiate(say_text,init_pos,new Quaternion(),transform.parent);
        tm.text = str;
    }

    protected override void FixedUpdate() {

        if (status == 0) {
            direction = fixDir(zDirDegree((target_pos - transform.position).normalized));
            if (!getInPos()) {
                Vector3 direction_vector = zEulerDegree(direction);
                rb.AddForce(force*direction_vector);
            } else {
                status = 1;
                recorded_direction = direction;
            }
        } else if (status == 1) {
            
            time ++;

            if (look_around) {
                if (time > 4f * 50) {
                    time = 0;
                    target_direction = recorded_direction += Random.Range(-1f,1f)*30f;
                }
            } else {
                target_direction = recorded_direction;
            }
            if (direction != target_direction) {
                float t = 1f * 50f / 360f;
                direction = Mathf.LerpAngle(direction,target_direction,t);
            }
            

        } else if (status == 2) {
            direction = fixDir(zDirDegree((out_pos - transform.position).normalized));
            
            Vector3 direction_vector = zEulerDegree(direction);
            rb.AddForce(force*direction_vector);

            //销毁
            if (Vector3.Distance(transform.position,MainPlayer_Single.me.transform.
            position) > 5000f) {
                Destroy(gameObject);
            }
           
        }

        float drag = force / (max_speed*max_speed);
        float v = rb.velocity.magnitude;
        Vector3 drag_force = (-rb.velocity).normalized*v*v*drag;
        rb.AddForce(drag_force);

        transform.eulerAngles = new Vector3(0f,0f,fixDir(direction-start_direction));

    }
 
}
