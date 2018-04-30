using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundSingleMinimap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void Init(Material bound_material,float width_multiplier = 1f) {
		
		LineRenderer lr = GetComponent<LineRenderer>();

		lr.material = bound_material;
		lr.widthMultiplier *= width_multiplier;

		Vector3[] ps = new Vector3[2];
		lr.GetPositions(ps);
		if (ps.Length != 2) throw new UnityException("Linerenderer of MapBoundSingle must have 2 points on it.");

		float distance = Vector3.Distance(ps[0],ps[1]);
		lr.materials[0].mainTextureScale = new Vector3(distance/120f,1,1);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
