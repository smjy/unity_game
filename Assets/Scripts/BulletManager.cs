using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public GameObject bullet;
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
    }
    void shoot() {
        Vector3 mp = Input.mousePosition;
        mp.z = 100f;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mp);
        pos.z = 100f;
        Vector3 start_pos = MainPlayer_Single.me.transform.position;
        Vector3 direction = (pos - start_pos).normalized;
        direction += Random.Range(0f, CursorFollow.main.accuracyRadius) * Random.onUnitSphere;
        CursorFollow.main.addSpeed(kick);
        create(start_pos + direction * 10f, direction);
    }
    void create(Vector3 position, Vector3 direction) {
        GameObject b = Instantiate(bullet, position, Random.rotation, bullet_parent);
        BulletController bc = b.GetComponent<BulletController>();
        bc.Init(direction, start_speed, speed_decrease, decrease_after, life);
    }
}
