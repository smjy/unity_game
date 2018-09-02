using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]
public class StoryCircle : MonoBehaviour {

	bool first = false;
    bool second = false;
    
    StoryChapter1 sc1 = null;
    
	void OnCollisionEnter(Collision collision)
    {
        if (sc1 == null) sc1 = StoryChapter1.main;
        if (collision.gameObject.GetComponent<MainPlayer_Single>()!=null) { 
            if (!first) {
                first = true;
                if (!sc1.b_colorRecovered)
                    sc1.addColorSystem();
            }

            if (first && sc1.b_colorRecovered && !second) {
                second = true;
                sc1.guideVisit();
            }

            if (second && sc1.b_reachBreakPos) {
                float imp = collision.impulse.magnitude;
                imp -= 9200f;

                if (imp > 0) {
                    float dis = Vector3.Distance(sc1.guide_main.transform.position,collision.contacts[0].point);
                    if (dis < 40f) {
                        sc1.hitCircle(collision.contacts[0].point);
                    } else {
                        sc1.notthere();
                    }            
                }
            }
        }
    }
}
