using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMesh))]
public class Story3DText : MonoBehaviour {

	public float fade_in_time = 1f;
    public float stay_time = 3f;
    public float fade_out_time = 1f;
    public float fly_speed = 0.05f;
    public bool destroy_after_faded = true;
	int time = 0;
	TextMesh tm;

	void Awake() {
		tm = GetComponent<TextMesh>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		time++;
        float alpha = 1f;
        if ((float)time/50f < fade_in_time) {
            alpha = (((float)time)/50f)/fade_in_time;
            transform.Translate(new Vector3(0f,fly_speed,0f));
        } 
        else if ((float)time/50f > fade_in_time + stay_time) {
            float fade_away = ((float)time/50f)-fade_in_time-stay_time;
            alpha = Mathf.Max(0f,1f-fade_away/fade_out_time);
            transform.Translate(new Vector3(0f,fly_speed,0f));
        }

        Color c = tm.color;
        c.a = alpha;
        tm.color = c;

        if (destroy_after_faded && (float)time/50f > fade_in_time + stay_time + fade_out_time) {
            Destroy(gameObject);
        }
	}
}
