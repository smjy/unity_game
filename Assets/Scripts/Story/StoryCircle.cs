using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]
public class StoryCircle : MonoBehaviour {

	bool first = false;
    bool second = false;
    
    
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MainPlayer_Single>()!=null) { 
            if (!first) {
                first = true;
                if (!StoryChapter1.main.b_colorRecovered)
                    StoryChapter1.main.addColorSystem();
            }

            if (first && StoryChapter1.main.b_colorRecovered && !second) {
                second = true;
                StoryChapter1.main.guideVisit();
            }
        }
    }
}
