using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    float speed_decrease;
    float decrease_after;
    float life = 4f;
    Vector3 direction;

    int time;
    float speed;
    public void Init(Vector3 d, float ss,float sd, float da, float l) {
        direction = d;
        speed_decrease = sd;
        speed = ss;
        life = l;
        decrease_after = da;
    }
    void Start () {
   
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time++;
        if (time / 50f > decrease_after) speed = Mathf.Max(speed - speed_decrease, 0f);
        if (time / 50f > life) Destroy(gameObject);
        transform.Translate(speed*direction,Space.World);
        

   	}
}
