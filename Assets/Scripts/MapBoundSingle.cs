using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MapBoundSingle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void Init(int boundtype = MapManager.BOUND_NORMAL) {
		switch(boundtype) {
			//TODO 边缘的类型(材质)
			case MapManager.BOUND_NORMAL: {

			} break;
			
		}
		LineRenderer lr = GetComponent<LineRenderer>();
		Vector3[] ps = new Vector3[2];
		lr.GetPositions(ps);
		if (ps.Length != 2) throw new UnityException("Linerenderer of MapBoundSingle must have 2 points on it.");

		float distance = Vector3.Distance(ps[0],ps[1]);
		lr.materials[0].mainTextureScale = new Vector3(distance/5f,1,1);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
