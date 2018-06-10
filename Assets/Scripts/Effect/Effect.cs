using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {


	[Tooltip("画面外是否消失")] public bool disappear = true;
	protected EffectGenerator generator;
	protected bool has_generator = false;

	float outsideDistance = 200f;
	float realDistance;

	//是否移动到画面外
	bool isOutside() {
		return Vector3.Distance(transform.position,MainPlayer_Single.me.transform.position) > realDistance;
	}
	void Start () {
		realDistance = EffectManager.screenRadius + outsideDistance;
	}
	public void init(EffectGenerator eg) {
		generator = eg;
		has_generator = true;
	}
	void Update() {
		if (disappear && isOutside()) {
			Debug.Log("Effect Destroyed");
			if (has_generator) 
				generator.remove(this);
			else 
				Destroy(gameObject);
		}
	}
	
}
