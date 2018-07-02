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

    public GameObject color_system;
    public GameObject contrast_system;

    [HideInInspector] public float contrastResolve = 0.001f; 
    [HideInInspector] public float saturationResolve = 0.998f;
    [HideInInspector] public float saturationMin = 0.975f;
    [HideInInspector] public float contrastMax = 0.025f;
    //章节时间点
    bool first = false;
    int t_startFade = 3;
    int t_startBlink = 5;
    int t_initSlot = 10;

    bool b_initSlot = false;
    [HideInInspector] public bool b_colorRecovered = false;
    [HideInInspector] public bool b_guideVisit = false;

    public static StoryChapter1 main;
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  

        cae = Camera.main.GetComponent<ColorAdjustEffect>();
    }

    void Start() {

    }

    public void setContrast(float contrast) {
        cae.contrast = contrast;
    }
    public void setSaturation(float saturation) {
        cae.saturation = saturation;
    }
    public void addColorSystem() {
        Vector3 pos = MainPlayer_Single.me.transform.position;
        pos.x = -0.95f*pos.x;
        pos.y = -0.95f*pos.y;
        pos.z = 100f;
        Instantiate(color_system,pos,Random.rotation,story_object_parent);

    }
    public void addContrastSystem() {
        Vector3 pos = MainPlayer_Single.me.transform.position;
        pos.Normalize();
        pos.x = -230f*pos.x;
        pos.y = -230f*pos.y;
        pos.z = 100f;
        Instantiate(contrast_system,pos,Random.rotation,story_object_parent);
        
    }
    void FixedUpdate() {
        timeFrame++;

        //时间展开
        if (!first) {
            //black_fade.gameObject.SetActive(true);
            first = true;
            cae.contrast = 3f;
            cae.saturation = 0f;
        }
        if (timeFrame == 50*t_startFade) {
            //black_fade.GetComponent<StoryFade>().enabled = true;
        } 
        else if (timeFrame > 50*t_startBlink && !b_colorRecovered) {
            
            float f = Random.Range(0f,1f);

            if (contrastResolve < contrastMax) {
                if (f< contrastResolve) {
                    cae.contrast = Random.Range(0.5f,1.2f);
                } else {
                    cae.contrast = 3f;
                }
            } else {
                cae.contrast = 1f;
            }
            
            if (saturationResolve > saturationMin) {
                if (f > saturationResolve) {
                    cae.saturation = Random.Range(0.8f,2f);
                } else {
                    cae.saturation = 0f;
                }
            } else {
                cae.saturation = 1f;
            }

            if (contrastResolve > contrastMax && saturationResolve < saturationMin) {
                b_colorRecovered = true;
            }
        }
        
        if (b_initSlot) {
            slots.SetActive(true);
            slot_manager.SetActive(true);

            b_initSlot = false;
        }

        if (b_guideVisit) {
            Debug.Log("visit!");
            b_guideVisit = false;
        }
    }


}
