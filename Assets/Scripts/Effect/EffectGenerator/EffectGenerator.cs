using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour {


    //效果生成器，在主角附近生成特效

    [Tooltip("最大特效数量")] public int max_effect = 10;
    [Tooltip("在屏幕外生成")] public bool generate_outside = true;
    [Tooltip("在屏幕外生成的距离最大值(像素)")] public float outside_max_distance = 1000f;
    //[Tooltip("在屏幕外生成的距离最小值(像素)")] public float outside_min_distance = 200f;
    [Tooltip("生成的特效集合")] public Effect[] effects;
    [Tooltip("每多少毫秒生成一次")] public int generate_time = 1000;
    [Tooltip("体积倍数下限")] public float scale_min = 0.5f;
    [Tooltip("体积倍数上限")] public float scale_max = 1.5f;
    [Tooltip("是否有初速度")] public bool has_speed = false;
    [Tooltip("初速度大小")] public float start_speed = 0f;
    [Tooltip("是否限制Z轴")] public bool speed_z = true;

    protected float outside_min_distance;
    protected int time;
    protected Region region;
        

    protected HashSet<Effect> current_effects = new HashSet<Effect>();

	protected virtual void Start () {
        outside_min_distance = EffectManager.screenRadius;
        outside_max_distance += outside_min_distance;
        //preGenerate();
	}
    public void setRegion(Region r) {
        region = r;
    }
    public virtual void preGenerate() {
        while(current_effects.Count<max_effect) {
            generate(false);
        }
    }
    public virtual void generate(bool outside = false) {
        if (effects.Length > 0) {
            Vector3 pos;
            float radius;
            if (outside) {
                radius = Random.Range(outside_min_distance,outside_max_distance);
            } else {
                radius = Random.Range(0f,outside_max_distance);
            }
            Vector3 rpos = new Vector3(Screen.width/2,Screen.height/2,GameManager.z_depth);
            pos = Camera.main.ScreenToWorldPoint(rpos);
            pos.z = GameManager.z_depth;
            float angle = Random.Range(0f,Mathf.PI*2);
            pos.x += radius*Mathf.Cos(angle);
            pos.y += radius*Mathf.Sin(angle);
            //特效生成到Effect/MapEffect空物体下 保证即使Region停用 Effect仍然留存
            Effect e = Instantiate(effects[Random.Range(0,effects.Length-1)],pos,Random.rotation,EffectManager.main.map_effect_parent) as Effect;
            Transform et = e.transform;
            et.localScale *= Random.Range(scale_min,scale_max);
            e.init(this);
            if (has_speed) {
                if (e.gameObject.GetComponent<Rigidbody>()!=null) {
                    Vector3 speeds = Random.onUnitSphere;
                    if (speed_z) {
                        speeds.z = 0f;
                        speeds.Normalize();
                    }
                    speeds *= start_speed;
                    e.gameObject.GetComponent<Rigidbody>().velocity = speeds;
                } else {
                    Debug.Log("没有找到RigidBody!");
                }
            }
            current_effects.Add(e);
        }
    }

    public void remove(Effect e) {
        if (current_effects.Contains(e)) {
            current_effects.Remove(e);
            Destroy(e);
            Destroy(e.gameObject);
        }
    }
    public void removeAll() {
        
    }
	void Update() {
        time++;
        if (time*Time.deltaTime*1000 > generate_time && region.has_user) {
            time = 0;
            if (effects.Length > 0 && current_effects.Count < max_effect) {
                //Debug.Log("Generate2!");
                generate(generate_outside);
            }
        }
		
	}
	
}
