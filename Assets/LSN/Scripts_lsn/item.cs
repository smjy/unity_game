using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class item : MonoBehaviour {
    public bool stackable;
	public bool usable = false;
    public Sprite sprite;
    public string description;
	// Use this for initialization
	protected virtual void Start () {
        // sprite = GetComponent<Image>().sprite;
        // description = name+"ksfjsdfjljfalk";
	}
	
	// Update is called once per frame
	protected  virtual void Update () {
		
	}

	//获得时触发
	public virtual void OnObtain() {

	}

	//丢失时触发
	public virtual void OnLost() {

	}

	//使用时触发
	public virtual void OnUse() {

	}
}
