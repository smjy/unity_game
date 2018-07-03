using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class StoryChapter1 : MonoBehaviour {

    [Header("调试模式")]
    public bool debug_open = true;

    [Header("剧情物体")]
    public StoryGuideAI Guide;
    StoryGuideAI guide_main;
    public Transform story_object_parent;
    public Transform story_text_parent;
    public Transform story_text2_parent;
    public ParticleSystem gate;
    public ParticleSystem distortion;
    public ParticleSystem core;
    public Image black_fade;
    public AudioSource bgm;
    public Animator black_img_anim;
    
    public StartSpeed item_minimap;
    public StartSpeed item_carnoon;

    //解锁主manager
    public GameObject slots;
    public GameObject slot_manager;
    ColorAdjustEffect cae;
    WaterWaveClickEffect wwce;
    public GameObject command_input;
    public StoryCircle sc;
    public GameObject minimap_system;
    
    public GameObject color_system;
    public GameObject contrast_system;

    //指引文本
    [Header("指引文本")]
    public Text text_wasd;
    public Text text_hitTheBall;
    public Text text_enterSay;
    public Text text_endChapter1;

    public Text text_endTest;

    [HideInInspector] public float contrastResolve = 0.001f; 
    [HideInInspector] public float saturationResolve = 0.998f;
    [HideInInspector] public float saturationMin = 0.975f;
    [HideInInspector] public float contrastMax = 0.025f;

    [HideInInspector] public bool in_story = true;
    [HideInInspector] public bool lockInput = false;

    //章节时间点
    int timeFrame = 0;
    bool first = false;
    int t_hint1 = 40; //40秒还没撞球就出提示
    int t_startFade = 3;
    int t_startBlink = 5;

    //向导出现
    int t_sayHello = 7;
    int t_sayWTF = 13;
    int t_enterSay = 17;
    int t_sayNext = 18;

    //成功对话
    int t_help = 6;
    int t_startHelp = 9;
    int t_sayFollow = 11;

    //开始碰撞
    int t_sayHit = 3;
    int t_sayHit2 = 10;

    int temp_hittimes = 0;

    //解放
    int t_sayFinal = 10;
    int t_sayFinal2 = 17;
    int t_sayFinal3 = 21;
    int t_sayFinal4 = 30;
    int t_endChapter = 38;

    //开关变量
    [HideInInspector] public bool b_hitted = false;
    [HideInInspector] public bool b_colorRecovered = false;
    [HideInInspector] public bool b_guideVisit = false;
    
    [HideInInspector] public bool b_initGuide = false;
    [HideInInspector] public bool b_aftersay = false;
    [HideInInspector] public bool b_reachBreakPos = false;
    [HideInInspector] public bool b_broken = false;

    public static StoryChapter1 main;
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  

        cae = Camera.main.GetComponent<ColorAdjustEffect>();
        wwce = Camera.main.GetComponent<WaterWaveClickEffect>();

    }

  
    bool reach(float rtime) {
        return timeFrame == 50*rtime;
    }
    bool more(float rtime) {
        return timeFrame > 50*rtime;
    }
    public void guideVisit() {
        b_guideVisit = true;
        timeFrame = 0;
    }
    public void saySomething(string str) {

        if (b_aftersay) return;

        if (str.Contains("Hello") && str.Contains("World")) {
            guide_main.say("Oh,congrats! Hi world too!");
        } else if (str.Contains("Fuck")) {
            guide_main.say("Why Fuck? You are so rude.");
        } else {
            guide_main.say("Oh,congrats! Now you know how to speak.");
        }

        b_aftersay = true;
        timeFrame = 0;

    }
    public void reachBreakPos() {
        b_reachBreakPos = true;
        timeFrame = 0;
        //guide_main.say("Hit here, the most fragile spot.");
    }
    void setCoreAlpha(float alpha) {
        ParticleSystem.MainModule mm = core.main;
        Color c = mm.startColor.color;
        c.a = alpha;
        mm.startColor = c;
    
    }
    public void hitCircle(Vector3 hitpos) {
        Vector3 vvs = Camera.main.WorldToScreenPoint(hitpos);
        Vector2 vs = new Vector2(vvs.x,vvs.y);
        wwce.exec(vs);

        temp_hittimes ++;
        if (temp_hittimes == 1) {
            setCoreAlpha(0.3f);
        } else if (temp_hittimes == 3) {
            setCoreAlpha(0.6f);
        } else if (temp_hittimes == 5) {
            setCoreAlpha(0.8f);
            guide_main.say("Oh! It's shaking!");
        } else if (temp_hittimes == 7) {
            breakCircle();
            b_broken = true;
            timeFrame = 0;
        }
    }
    void breakCircle() {
        DestroyAfter da = core.gameObject.AddComponent<DestroyAfter>();
        guide_main.status = 5;
        da.destroy_after = 10f;
        sc.gameObject.SetActive(false);
    }
    void giveItem() {
        StartSpeed ss1 = Instantiate(item_minimap,guide_main.transform.position, Random.rotation, story_object_parent);
        StartSpeed ss2 = Instantiate(item_carnoon,guide_main.transform.position, Random.rotation, story_object_parent);
        Vector3 vv = guide_main.transform.position - MainPlayer_Single.me.transform.position;
        vv.Normalize();
        vv+=Random.onUnitSphere*0.1f;
        ss1.start_speed = vv*1.9f;
        ss2.start_speed = vv* 2.3f;
    }
    public void setContrast(float contrast) {
        cae.contrast = contrast;
    }
    public void setSaturation(float saturation) {
        cae.saturation = saturation;
    }
    public void addColorSystem() {
        Vector3 pos = MainPlayer_Single.me.transform.position;
        pos.x = -0.9f*pos.x;
        pos.y = -0.9f*pos.y;
        pos.z = 100f;
        Instantiate(color_system,pos,Random.rotation,story_object_parent);

    }
    public void addContrastSystem() {
        b_hitted = true;
        Vector3 pos = MainPlayer_Single.me.transform.position;
        pos.Normalize();
        pos.x = -230f*pos.x;
        pos.y = -230f*pos.y;
        pos.z = 100f;
        Instantiate(contrast_system,pos,Random.rotation,story_object_parent);
        
    }

    public void activeMinimap() {
        minimap_system.SetActive(true);
    }
    public void activeSlot() {
        slots.SetActive(true);
        slot_manager.SetActive(true);
    }
    public void activeCommandOutput() {
        CommandOutput.main.active = true;
    }
    
    void FixedUpdate() {
        timeFrame++;
        if (debug_open) {
            first = true;
            debug_open = false;
            cae.saturation = 1f;
            cae.contrast = 1f;
            b_colorRecovered = true;
            //b_guideVisit = true;
            b_hitted = true;
            
        }
        //时间展开
        if (!first) {
            black_fade.gameObject.SetActive(true);
            first = true;
            cae.contrast = 3f;
            cae.saturation = 0f;
        }
        //被困部分
        if (!b_guideVisit) {
            if (reach(t_startFade)) {
                Instantiate(text_wasd,story_text_parent);
                black_fade.GetComponent<StoryFade>().enabled = true;
            } 
            else if (more(t_startBlink) && !b_colorRecovered) {
                
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
                    cae.enabled = false;
                }
            }
            
            //提示部分
            if (reach(t_hint1) && !b_hitted) {
                Instantiate(text_hitTheBall,story_text_parent); 
            }
        }

        //开始向导阶段
        if (b_guideVisit && !b_aftersay) {
            if (!b_initGuide) {
                b_initGuide = true;
                Debug.Log("visit!");
                Vector3 player_pos = MainPlayer_Single.me.transform.position;
                Vector3 init_pos = player_pos * 1.7f;
                init_pos.z = 100f;
                Vector3 coming_pos = player_pos * 1.2f;
                coming_pos.z = 100f;
                Vector3 out_pos = Random.onUnitSphere*8400f;
                out_pos.z = 100f;

                guide_main = Instantiate(Guide,init_pos,Random.rotation,story_object_parent);
                guide_main.target_pos = coming_pos;
                guide_main.out_pos = out_pos;
                lockInput = true;
                black_img_anim.Play("bi_show");
            }

            if (reach(t_sayHello)) {
                guide_main.say("Hello?");
            } 
            else if (reach(t_sayWTF)) {
                guide_main.look_around = true;
                guide_main.say("What happened to you? \n An Isolation Zone?");
            }
            else if (reach(t_enterSay)) {
                Instantiate(text_enterSay,story_text_parent);
                command_input.SetActive(true);
                lockInput = false;
                black_img_anim.Play("bi_hide");
            }   
            else if (reach(t_sayNext)) {
                guide_main.say("Hey, please say something.");
            }   
        }
        //变向
        if (b_aftersay && !b_reachBreakPos) {
            if (reach(t_help)) {
                guide_main.say("Don't worry.\n I can help you get out of there.");
                guide_main.look_around = false;
                
            } 
            else if (reach(t_startHelp)) {
                guide_main.findPos();
            } 
            if (reach(t_sayFollow)) {
                guide_main.say("Follow me.");
            } 
        }

        if (b_reachBreakPos && !b_broken) {
            if (reach(t_sayHit)) {
                guide_main.say("Hit here, the most fragile spot.");
            }
            else if (temp_hittimes == 0 && reach(t_sayHit2)) {
                guide_main.say("I mean, just speeding up to me!");
            }
        }

        if (b_broken) {
            if (core != null) {
                gate.transform.localScale *= 1.05f;
                distortion.transform.localScale *= 1.02f;
                core.transform.localScale *= 0.9f;
            }

            if (reach(t_sayFinal)) {
                guide_main.say("Wow, that explosion was amazing right?");
            }
            else if (reach(t_sayFinal2)) {
                guide_main.say("It was our destiny to meet, "+PlayerStat.main.player_name+".");
            }
            else if (reach(t_sayFinal3)) {
                guide_main.say("Let me share you these.");
            }
            else if (reach(t_sayFinal3 + 40)) {
                giveItem();
            }
            else if (reach(t_sayFinal4)) {
                guide_main.say("You'll know how to deal with them, bye!");
                entTest();
            }
            else if (reach(t_endChapter)) {
                guide_main.status = 2;
                Instantiate(text_endChapter1,story_text2_parent);
                in_story = false;
                b_broken = false;
                activeSlot();
            }
        }
    }

    void entTest() {
        Instantiate(text_endTest,story_text_parent);
    }

}
