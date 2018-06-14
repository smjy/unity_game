using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {
    
    public float destroy_after = 3f;

    int time = 0;

    void FixedUpdate() {
        time++;
        if ((float)time/50f > destroy_after) 
            Destroy(gameObject);
    }
}
