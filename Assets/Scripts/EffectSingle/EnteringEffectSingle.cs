using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringEffectSingle : MonoBehaviour {

	public float ctime = 2f;
	
	int time = 0;
	float totalframe;
	float zspeed = 2f;

	SpriteRenderer sr;
	
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		totalframe = ctime/Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		time++;
		float currspeed = zspeed * (1f - time / totalframe);
		transform.Rotate(0,0,currspeed);
		setAlpha(1f - time / totalframe);
		if (time > totalframe) Destroy(gameObject);
	}

	void setAlpha(float alpha){
		Color c = sr.color;
		c.a = alpha;
		sr.color = c;

	}
}
