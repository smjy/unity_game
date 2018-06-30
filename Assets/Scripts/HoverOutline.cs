using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class HoverOutline : MonoBehaviour {

	Outline o;
	// int alpha_time = 1; // 0 初始 1 增加 2 完全 3 减少
	// int time = 0;
	// int status = 0;

	void OnMouseEnter() {
		o.enabled = true;
	}
	void OnMouseExit() {
		o.enabled = false;
	}
	void Awake() {
		o = gameObject.GetComponent<Outline>();
		o.enabled = false;
	}

	// // Update is called once per frame
	// void Update () {
	// 	if (status == 1) {
	// 		Color c = o.OutlineColor;
	// 		time ++;
	// 		c.a = (float)time*Time.deltaTime/(float)alpha_time;
	// 		o.OutlineColor = c;
	// 		if (time > alpha_time / Time.deltaTime) {
	// 			status = 2;
	// 			time = 0;
	// 		}
	// 	} else if (status == 3) {
	// 		Color c = o.OutlineColor;
	// 		time ++;
	// 		c.a = 1f-(float)time*Time.deltaTime/(float)alpha_time;
	// 		o.OutlineColor = c;
	// 		if (time > alpha_time / Time.deltaTime) {
	// 			status = 0;
	// 			time = 0;
	// 		}
	// 	}
	// }
}
