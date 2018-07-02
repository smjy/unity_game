using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryChapter1 : MonoBehaviour {

    public GameObject Guide;
    public Transform story_object_parent;
    public ParticleSystem gate;
    public Image black_fade;
    public GameObject slots;
    public GameObject slot_manager;
    ColorAdjustEffect cae;

    int timeFrame = 0;
    
    //章节时间点
    bool first = false;
    int t_startFade = 3;
    int t_startBlink = 5;
    int t_initSlot = 10;

    bool b_initSlot = false;
    bool b_colorRecovered = false;
    void Awake() {
        cae = Camera.main.GetComponent<ColorAdjustEffect>();
    }
    void Start() {

    }

    void FixedUpdate() {
        timeFrame++;

        //时间展开
        if (!first) {
            black_fade.gameObject.SetActive(true);
            first = true;
            cae.contrast = 3f;
            cae.saturation = 0f;
        }
        if (timeFrame == 50*t_startFade) {
            black_fade.GetComponent<StoryFade>().enabled = true;
        } 
        else if (timeFrame > 50*t_startBlink + 3 && !b_colorRecovered) {
            float f = Random.Range(0f,1f);
            if (f< 0.001f) {
                cae.contrast = Random.Range(0.5f,1.2f);
            } else if (f > 0.998f) {
                cae.saturation = Random.Range(0.8f,2f);
            } else {
                cae.contrast = 3f;
                cae.saturation = 0f;
            }
        }
        
        if (b_initSlot) {
            slots.SetActive(true);
            slot_manager.SetActive(true);

            b_initSlot = false;
        }
    }


}
