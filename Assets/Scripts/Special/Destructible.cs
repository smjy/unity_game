using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Destructible : MonoBehaviour {

    public float break_force_min = 10000f;
    public float break_force_max = 80000f;
    public float upwards = 4f;
    
    Vector3 oldPos2;
    AudioSource asc;
    void Start() {
        oldPos2 = transform.position;
        if (GetComponent<AudioSource>()!=null) {
            asc = GetComponent<AudioSource>();
            Debug.Log("1");
        }
        else       
            asc = AudioClips.main.ass;
    }
    public void trigger() {
        
        GetComponent<Collider>().enabled = false;
        Transform[] ts = GetComponentsInChildren<Transform>();
        FontEffectManager.main.createRandNumAtPos(Random.Range(1,6),transform.position);
        gameObject.AddComponent<DestroyAfter>().destroy_after = 4f;
        if (GetComponent<MinimapIconHook>()!=null) {
            GetComponent<MinimapIconHook>().iconDestroy();
        }
        Vector3 currVelocity = GetComponent<Rigidbody>().velocity;
        asc.PlayOneShot(AudioClips.main.ac[9]);
        foreach (Transform t in ts) {
            if (t.gameObject.GetComponent<Destructible_remove>()!=null) {
                Destroy(t.gameObject);
                continue;
            }
            if (t.gameObject.GetComponent<BoxCollider>()!=null && t.gameObject!=gameObject) {
                //Debug.Log("Active1");
                GameObject g = t.gameObject;
                Fade f = g.AddComponent<Fade>();
                f.fade_after = 2f;
                f.fade_time = 2f;
                g.AddComponent<FadeInZ>();
                Vector3 oldpos = t.position;
                t.gameObject.GetComponent<BoxCollider>().enabled = true;
                t.position = oldpos;

                Rigidbody r = g.GetComponent<Rigidbody>();
                float force = Random.Range(break_force_min,break_force_max);
                r.velocity = currVelocity;
                r.AddExplosionForce(force,oldPos2,200f,upwards,ForceMode.Impulse);
                
                
            } 
            
        }

        
    }
}
