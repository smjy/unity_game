using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour {

    RectTransform r;
    Animator a;
    Vector3 oldpos, newpos ,diff;
    float currSpeed = 0f;
    
    public float accuracyRadius {
        get {
            float minRadius = 0.015f; //最小准心半径
            float maxRadius = 0.042f; //最大准心半径
            return currSpeed*(maxRadius - minRadius)+minRadius;
        }
    }
    public static CursorFollow main;
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);
    }

    void Start () {
        r = GetComponent<RectTransform>();
        a = GetComponent<Animator>();
        oldpos = new Vector3(0, 0, -1000);
        a.speed = 0f;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !Cursor.visible;
        }
        newpos = Input.mousePosition;
        if (oldpos.z > -500) diff = newpos - oldpos;
        oldpos = newpos;
        r.anchoredPosition = newpos;
        float mouseSpeed = diff.magnitude;
        
        mouseSpeed = (mouseSpeed - 3f) / 170f;
        currSpeed = Mathf.Clamp(currSpeed + mouseSpeed,0f,0.99f);
        a.Play("CursorAnim", 0, currSpeed);
		//Input.mousePosition
	}

    public void addSpeed(float kick) {
        currSpeed = Mathf.Clamp(currSpeed + kick, 0f, 0.99f);
    }

   
}
