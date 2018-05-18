using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {


	[Tooltip("画面外是否消失")] public bool disappear = true;

	float outsideDistance = 100;

	//是否移动到画面外
	bool isOutside() {
		Vector3 v = Camera.main.WorldToScreenPoint(transform.position);
		return (v.x < -outsideDistance || v.x > Screen.width+outsideDistance || v.y < -outsideDistance || v.y > Screen.height+outsideDistance);
	}
	void Start () {

	}
	
	void Update() {
		if (disappear && isOutside()) Destroy(gameObject);
	}
	
}
