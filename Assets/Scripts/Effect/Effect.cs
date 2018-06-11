using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {


	[Tooltip("画面外是否消失")] public bool disappear = true;
	protected EffectGenerator generator = null;

	float outsideDistance = 2000f;
	float realDistance;

	//是否移动到画面外
	bool isOutside() {
		//Debug.Log("Distance:"+Vector3.Distance(transform.position,MainPlayer_Single.me.transform.position));
		//Debug.Log("MaxDistance:"+realDistance);

		return Vector3.Distance(transform.position,MainPlayer_Single.me.transform.position) > realDistance;
	}
	void Start () {
		realDistance = EffectManager.screenRadius + outsideDistance;
	}
	public void init(EffectGenerator eg) {
		generator = eg;
	}
	void Update() {
		if (disappear && isOutside()) {
			Debug.Log("Effect Destroyed");
			if (generator != null)
				generator.remove(this);
			else 
				Destroy(gameObject);
		}
	}
	
}
