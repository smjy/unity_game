using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//事件生成器简化
[RequireComponent(typeof(Region))]
public class RegionEventCarrier : MonoBehaviour {


    public List<objMax> RegionObjEvents = new List<objMax>();
    public List<GameObject> currObjs = new List<GameObject>();
    
    public float outside_max_distance = 500f;
    Region r;

    protected float outside_min_distance;
    int time = 0;
    int updatetime = 5;
    [System.Serializable]
    public class objMax {
        public GameObject obj;
        public int max_num = 1;
    }
    
    Vector3 newObjPos() {
        Vector3 pos;
        float radius;
        radius = Random.Range(outside_min_distance,outside_max_distance);
      
        Vector3 rpos = new Vector3(Screen.width/2,Screen.height/2,GameManager.z_depth);
        pos = Camera.main.ScreenToWorldPoint(rpos);
        pos.z = GameManager.z_depth;
        float angle = Random.Range(0f,Mathf.PI*2);
        pos.x += radius*Mathf.Cos(angle);
        pos.y += radius*Mathf.Sin(angle);
        return pos;
    }

    void Awake() {
        r = GetComponent<Region>();
    }
    void Start() {
        outside_min_distance = EffectManager.screenRadius + 500f;
        outside_max_distance += outside_min_distance;

        preUpdate();
    }
    public void preUpdate() {
        foreach (objMax om in RegionObjEvents) {
            for (int i=0;i<om.max_num;i++) {
                GameObject newObj = Instantiate(om.obj,newObjPos(),new Quaternion(),r.getObjEvents());
                currObjs.Add(newObj);
            }
                
        }
    }
    void updateNew() {
        for(int i=0;i<currObjs.Count;i++) {
            GameObject go = currObjs[i];
            if (go==null) currObjs.Remove(go);
        }
    }

    void FixedUpdate() {
        time++;

        if (time*50 > updatetime) {
            updateNew();
            time = 0;
        }
    }
}
