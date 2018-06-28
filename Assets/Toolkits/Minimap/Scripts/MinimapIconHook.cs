using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconHook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		MinimapManager.instance.RegisterObj(transform, MinimapManager.instance.icon1);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
