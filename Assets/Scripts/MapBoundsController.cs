using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundsController : MonoBehaviour {

	public GameObject mapBoundSingle;
	// Use this for initialization
	void Start () {	
		
	}
	public void Init(float width,float height, float startx,float starty,int boundtype = MapManager.BOUND_NORMAL) {

		// this.width = width;
		// this.height = height;
		// this.left = startx;
		// this.right = startx+width;
		// this.top = starty+height;
		// this.bottom = starty;

		//初始化四条边
		GameObject bound_left = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_left = bound_left.GetComponent<LineRenderer>();
		Vector3[] leftpos = {new Vector3(startx,starty,100f),new Vector3(startx,starty+height,100f)};
		lr_left.SetPositions(leftpos);
		bound_left.GetComponent<MapBoundSingle>().Init(boundtype);

		GameObject bound_right = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_right = bound_right.GetComponent<LineRenderer>();
		Vector3[] rightpos = {new Vector3(startx+width,starty,100f),new Vector3(startx+width,starty+height,100f)};
		lr_right.SetPositions(rightpos);
		bound_right.GetComponent<MapBoundSingle>().Init(boundtype);

		GameObject bound_top = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_top = bound_top.GetComponent<LineRenderer>();
		Vector3[] toppos = {new Vector3(startx,starty+height,100f),new Vector3(startx+width,starty+height,100f)};
		lr_top.SetPositions(toppos);
		bound_top.GetComponent<MapBoundSingle>().Init(boundtype);

		GameObject bound_bottom = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_bottom = bound_bottom.GetComponent<LineRenderer>();
		Vector3[] bottompos = {new Vector3(startx,starty,100f),new Vector3(startx+width,starty,100f)};
		lr_bottom.SetPositions(bottompos);
		bound_bottom.GetComponent<MapBoundSingle>().Init(boundtype);

	}

	public void setRegion() {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
