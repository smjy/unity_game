using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class  FollowObtainIO : ItemObject {

    public float following_distance = 40f;
    float follow_speed = 2f;
    
    protected override void Awake() {
        base.Awake();

    }
    protected virtual void Update() {
        float vd =  Vector3.Distance(MainPlayer_Single.me.transform.position,transform.position);
        if (following_distance > vd) {
            Vector3 dir = MainPlayer_Single.me.transform.position - transform.position;
            dir.Normalize();
            rb.AddForce(dir*follow_speed,ForceMode.VelocityChange);
            
        }
    }


    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<MainPlayer_Single>() != null) {
            transform.parent = package.main.wp;
            if (GetComponent<SpriteRenderer>() != null) {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            for (int i = 0; i < transform.childCount; i++) {
                Destroy (transform.GetChild (i).gameObject);
            }
            package.main.additem(ii);
            Destroy(this);
        }
    }
    
}
