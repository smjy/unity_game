using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontEffectManager : MonoBehaviour {

    public static FontEffectManager main;
    public RectTransform target_transform;
    public GameObject word;
    public Transform font_parent;
    public float default_force = .1f;

    private void Awake()
    {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
    }

    void create(char c,Vector3 position)
    {
        Vector3 randVector = Random.onUnitSphere;
        create(c, position, randVector, default_force);
    }
    void create(char c, Vector3 position, Vector3 direction)
    {
        create(c, position, direction, default_force);
    }
    void create(char c, Vector3 position, Vector3 direction,float force)
    {
        direction.Normalize();
        GameObject w = Instantiate(word,position,Random.rotation,font_parent);
        WordController wc = w.GetComponent<WordController>();
        wc.Init(c, force * direction, force * 0.01f, target_transform);

    }

    void createRandNum(int num) {
        for (int i =0;i<num;i++) {
            char c = (char)Random.Range(0, 25);
            c += 'a';
            create(c, new Vector3(0, 0, 100), Random.onUnitSphere,Random.Range(default_force*0.7f, default_force*1.4f));
        }
    }
    void createRandNumAtPos(int num,Vector3 pos) {
        for (int i =0;i<num;i++) {
            char c = (char)Random.Range(0, 25);
            c += 'a';
            create(c, pos, Random.onUnitSphere,Random.Range(default_force*0.7f, default_force*1.4f));
        }
    }
	void Start () {
        
	}
	
	void Update () {
        //测试鼠标点击生成
        //if (Input.GetMouseButtonDown(0)) {
        if (CommandInput.main != null && CommandInput.main.N()) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 mp = Input.mousePosition;
            mp.z = 100f;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mp);
            createRandNumAtPos(10,pos);
        }

        

        
    }

   
}
