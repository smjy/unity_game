using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
    public static EffectManager main;
    public static float screenRadius;
    public Transform effect_parent;
    public Transform map_effect_parent;
    public Effect entering_effect;
    public Effect[] hit_effects;

    public GameObject Tracker;

	private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
    }

   
    void Start () {

        Vector3 pos1 = new Vector3(0,0,GameManager.z_depth);
        Vector3 pos2 = new Vector3(Screen.width/2,Screen.height/2,GameManager.z_depth);
        pos1 = Camera.main.ScreenToWorldPoint(pos1);
        pos2 = Camera.main.ScreenToWorldPoint(pos2);
        pos1.z = GameManager.z_depth;
        pos2.z = GameManager.z_depth;

        screenRadius = Vector3.Distance(pos1,pos2);
        Debug.Log("Screen Radius in world space:"+screenRadius.ToString());
    }

	void Update () {
		
	}

    public Effect get_hit_effect() {
        if (hit_effects.Length == 0) {
            Debug.Log("error,no effects");
            throw new UnityException("error,no effects");
        }
        return hit_effects[Random.Range(0,hit_effects.Length)];
    }
}
