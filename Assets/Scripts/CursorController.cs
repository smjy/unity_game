using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class CursorController : MonoBehaviour {

    const int CURSOR_EXPLORE = 1;
    const int CURSOR_AIM = 2;
    const int CURSOR_TEST = 2;
    
    public CursorType cursor_aim;
    public CursorType cursor_test;


    CursorType currentType;
    CursorType nextType;
    static float switchScale = 3f;
    static float switchAlpha = 0f;
    static float switchRotation = 90f;
    CursorStatus switchTo = new CursorStatus();
    CursorStatus[] switchStartStatus = new CursorStatus[10];
    float switchTime = 0.2f; //second
    int switchTimeSec = 0;
    int switchStatus = 0; //0 idle 1 disappear 2 appear

    [System.Serializable]
    public class CursorType {
        public CursorSprite[] cursorSprites;
        public string typeName;
        public float moveThreshold = .5f;
        public float recoverThreshold = 1f;
        public float clickThreshold = 1f;
        public bool enabledMovement = true;
    }
    [System.Serializable] 
    public class CursorSprite {
        
        public GameObject sprite;
        public CursorStatus initStatus;
        public CursorStatus[] cursorStatus;

        CursorSprite() {
            if (sprite != null) {
                setSpriteScale(sprite,initStatus.scale);
                setSpriteAlpha(sprite,initStatus.alpha);
            }
        }

        public void preInit() {
            setSpriteScale(sprite,switchScale);
            setSpriteAlpha(sprite,switchAlpha);
            setSpriteRotation(sprite,-switchRotation);
        }
    }
    [System.Serializable] 
    public class CursorStatus {
        public float scale = 1f;
        public float alpha = 1f;
        public float rotation = 0f;
    }

    int _status = CURSOR_AIM;
    public int status {
        get {
            return _status;
        }
    }

    RectTransform r;
    Vector3 oldpos, newpos ,diff;
    float currSpeed = 0f;
    
    public float accuracyRadius {
        get {
            float minRadius = 0.015f; //最小准心半径
            float maxRadius = 0.042f; //最大准心半径
            return currSpeed*(maxRadius - minRadius)+minRadius;
        }
    }

    
    public static CursorController main;
    private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);
    }

    void Start () {
        currentType = cursor_test;
        nextType = null;
        setCursorTypeActive(currentType,true);

        switchTo.scale = switchScale;
        switchTo.alpha = switchAlpha;
        switchTo.rotation = switchRotation;

        r = GetComponent<RectTransform>();
        oldpos = new Vector3(0, 0, -1000);
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (KeySetManager.GetKeyDown("Menu")) {
            Cursor.visible = !Cursor.visible;
        }
        newpos = Input.mousePosition;
        if (oldpos.z > -500) diff = newpos - oldpos;
        oldpos = newpos;
        r.anchoredPosition = new Vector2(newpos.x,newpos.y);
    
        switch(switchStatus) {
            case 0: {
                float mouseSpeed = diff.magnitude;
        
                mouseSpeed = (mouseSpeed*currentType.moveThreshold - 3f*currentType.recoverThreshold) / 170f;
                currSpeed = Mathf.Clamp(currSpeed + mouseSpeed,0f,1f);
                
                if (currentType.enabledMovement) {
                    int i=0;
                    foreach (CursorSprite csp in currentType.cursorSprites) {
                        if (csp.cursorStatus.Length>0) {
                            setCursor(csp,csp.cursorStatus[0],currSpeed);
                        }
                        CursorStatus tmp = new CursorStatus();
                        tmp.scale = csp.sprite.transform.localScale.x;
                        tmp.alpha = csp.sprite.GetComponent<SpriteRenderer>().material.color.a;
                        tmp.rotation = csp.sprite.transform.localEulerAngles.z;
                        switchStartStatus[i] = tmp;
                        i++;
                    }
                }

                // 切换光标
                // if (Input.GetKeyDown(KeyCode.Z)) {
                //     switchType(cursor_test);
                // }
                // if (Input.GetKeyDown(KeyCode.C)) {
                //     switchType(cursor_aim);
                // }
            } break;
            case 1: {
                
                switchTimeSec++;
                float f = Mathf.Clamp((float)switchTimeSec*Time.deltaTime/switchTime,0f,1f);
                f = Easing.EaseIn(f,EasingType.Quartic);
                for (int i=0; i < currentType.cursorSprites.Length; i++){
                    setCursor(currentType.cursorSprites[i],switchStartStatus[i],switchTo,f);
                }
                if (switchTimeSec > (float)switchTime/Time.deltaTime) {
                    switchStatus = 2;
                    switchTimeSec = 0;
                    setCursorTypeActive(currentType,false);
                    switchTo.rotation = -switchTo.rotation;
                    currentType = nextType;

                   
                }
            } break;
            case 2: {
                switchTimeSec++;
                float f = Mathf.Clamp((float)switchTimeSec*Time.deltaTime/switchTime,0f,1f);
                f = Easing.EaseOut(f,EasingType.Quartic);

                for (int i=0; i < currentType.cursorSprites.Length; i++){
                    setCursor(currentType.cursorSprites[i],switchTo,currentType.cursorSprites[i].initStatus,f);
                }
                if (switchTimeSec > (float)switchTime/Time.deltaTime) {
                    switchStatus = 0;
                    switchTimeSec = 0;
                    switchTo.rotation = -switchTo.rotation;
                    nextType = null;
                }
            } break;
        }
		//Input.mousePosition
	}
   
    public void switchType(CursorType to) {

        if (currentType == to) return;
        
        nextType = to;
        setCursorTypeActive(to,true);
        preInitType(to);
        switchStatus = 1;
        
    }

    public void addSpeed(float kick) {
        currSpeed = Mathf.Clamp(currSpeed + kick*currentType.clickThreshold, 0f, 1f);
    }

    static void setCursorTypeActive(CursorType ct,bool b) {
        foreach(CursorSprite csp in ct.cursorSprites) {
            csp.sprite.SetActive(b);
        }
    }
    static void preInitType(CursorType ct) {
        foreach(CursorSprite csp in ct.cursorSprites) {
            csp.preInit();
        }
    }

    static void setCursor(CursorSprite cs,CursorStatus css) {
        setSpriteAlpha(cs.sprite,css.alpha);
        setSpriteScale(cs.sprite,css.scale);
        setSpriteRotation(cs.sprite,css.rotation);
    }
    static void setCursor(CursorSprite cs,CursorStatus csto,float f) {
        setSpriteAlpha(cs.sprite,Mathf.Lerp(cs.initStatus.alpha,csto.alpha,f));
        setSpriteScale(cs.sprite,Mathf.Lerp(cs.initStatus.scale,csto.scale,f));
        setSpriteRotation(cs.sprite,Mathf.Lerp(cs.initStatus.rotation,csto.rotation,f));
    }
    static void setCursor(CursorSprite cs,CursorStatus csfrom,CursorStatus csto,float f) {
        setSpriteAlpha(cs.sprite,Mathf.Lerp(csfrom.alpha,csto.alpha,f));
        setSpriteScale(cs.sprite,Mathf.Lerp(csfrom.scale,csto.scale,f));
        setSpriteRotation(cs.sprite,Mathf.Lerp(csfrom.rotation,csto.rotation,f));
    }
    static void setSpriteAlpha(GameObject g,float alpha) {
        if (g.GetComponent<SpriteRenderer>()==null) 
            throw(new UnityException("Cursor sprite Not containing component SpriteRenderer"));
        SpriteRenderer s = g.GetComponent<SpriteRenderer>();
        Color c = s.material.color;
        c.a = Mathf.Clamp(alpha,0f,1f);
        s.material.color = c;
    }
    static void setSpriteScale(GameObject g,float scale) {
        g.transform.localScale = new Vector3(scale,scale,g.transform.localScale.z);
    }
    static void setSpriteRotation(GameObject g,float rotation) {
        g.transform.localEulerAngles = new Vector3(g.transform.localEulerAngles.x,g.transform.localEulerAngles.y,rotation);
    }

   
}
