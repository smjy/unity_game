using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Toggle btn = this.GetComponent<Toggle>();
        UIEventListener btnListener = btn.gameObject.AddComponent<UIEventListener>();
        btnListener.OnClick += delegate (GameObject gb) {
            
            gb.GetComponentInChildren<AudioSource>().Play();
        };
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
