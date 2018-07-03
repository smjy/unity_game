using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//需要渐变出现和消失的文字
[RequireComponent(typeof(Text))]
public class TextFadeInOut : MonoBehaviour {
    
    public float fade_in_time = 1f;
    public float stay_time = 5f;
    public float fade_out_time = 1f;
    public bool destroy_after_faded = true;
    int time = 0;
    Text t;
    void Start() {
        t = GetComponent<Text>();
    }
    void FixedUpdate() {
        time++;
        float alpha = 1f;
        if ((float)time/50f < fade_in_time) {
            alpha = (((float)time)/50f)/fade_in_time;
        } 
        else if ((float)time/50f > fade_in_time + stay_time) {
            float fade_away = ((float)time/50f)-fade_in_time-stay_time;
            alpha = Mathf.Max(0f,1f-fade_away/fade_out_time);
        }

        Color c = t.color;
        c.a = alpha;
        t.color = c;

        if (destroy_after_faded && (float)time/50f > fade_in_time + stay_time + fade_out_time) {
            Destroy(gameObject);
        }
        

    }
}
