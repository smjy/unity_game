using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//需要渐变消失的物体
[RequireComponent(typeof(MeshRenderer))]
public class Fade : MonoBehaviour {
    
    public float fade_time = 3f;
    public float fade_after = 0f;
    int time = 0;
    MeshRenderer mr;
    void Start() {
        if (GetComponent<MeshRenderer>()!=null) {
            mr = GetComponent<MeshRenderer>();
        }
    }
    void FixedUpdate() {
        time++;
        if ((float)time/50f > fade_after) {
            float alpha = 1f - (((float)time)/50f - fade_after)/fade_time;
            if (alpha < 0) {
                gameObject.SetActive(false);
                return;
            }
            Color c = mr.material.color;
            //可以同步操作alpha
            if (c.a>alpha) c.a = alpha;
            mr.material.color = c;
            
        }
        

    }
}
