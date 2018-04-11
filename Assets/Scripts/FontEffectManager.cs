using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontEffectManager : MonoBehaviour {

    public static FontEffectManager main;
    public Text target_text;
    public GameObject word;
    public float default_force = 10f;
    public float default_torque_force = 10f;

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
        string s = c.ToString();
        GameObject w = Instantiate(word,position,Random.rotation);
        w.GetComponent<TextMesh>().text = s;
        WordController wc = w.GetComponent<WordController>();
        wc.target_text = target_text;
        Rigidbody r = w.GetComponent<Rigidbody>();
        r.AddForce(force * direction); //施加初始作用力
        r.AddTorque(default_torque_force * Random.onUnitSphere); //随机施加旋转力
    }
	// Use this for initialization
	void Start () {
        for (int i =0;i<30;i++) {
            char c = (char)Random.Range(0, 25);
            c += 'a';
            create(c, new Vector3(0, 0, 100), Random.onUnitSphere,Random.Range(default_force*0.7f, default_force*1.4f));
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
