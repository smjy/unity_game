using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public GameObject bullet;
    public Transform carnoon;
    public Transform bullet_parent;

    public float start_speed = 3f;
    public float speed_decrease = 0.05f;
    public float decrease_after = 2f;
    public float life = 6f;

    public float reload_time = 0.3f; //second
    public float kick = 0.7f; //后坐力
    int time = 0;
	// Use this for initialization

    
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (time < reload_time / Time.deltaTime) time++;
        else if (Input.GetMouseButton(0)) {
            shoot();
            time = 0;
        }
        Vector3 mv = Input.mousePosition;
        mv.z = 100f;
        Vector3 diff = Camera.main.ScreenToWorldPoint(mv)-MainPlayer_Single.me.transform.position;
        //Vector3 diff = Camera.main.ScreenToWorldPoint(mv);
        Vector3 angle;
        if (diff.x>=0) angle = new Vector3(0,0,Mathf.Atan(diff.y/diff.x)*180f/Mathf.PI);
        else angle = new Vector3(0,0,-Mathf.Atan(-diff.y/diff.x)*180f/Mathf.PI+180f);
        carnoon.eulerAngles = angle;
        

    }
    void shoot() {
        Vector3 mp = Input.mousePosition;
        mp.z = 100f;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mp);
        pos.z = 100f;
        Vector3 start_pos = MainPlayer_Single.me.transform.position;
        Vector3 direction = (pos - start_pos).normalized;
        direction += Random.Range(0f, CursorController.main.accuracyRadius) * Random.onUnitSphere;
        CursorController.main.addSpeed(kick);
        create(start_pos + direction * 10f, direction);
    }
    void create(Vector3 position, Vector3 direction) {
        GameObject b = Instantiate(bullet, position, Random.rotation, bullet_parent);
        BulletController bc = b.GetComponent<BulletController>();
        bc.Init(direction, start_speed, speed_decrease, decrease_after, life);
    }
}
