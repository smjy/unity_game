using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBoundsController : MonoBehaviour {

	public GameObject mapBoundSingle;
	public GameObject mapBoundSingleMinimap;
	
	[HideInInspector] public float left,right,top,bottom;
	// Use this for initialization
	void Start () {	
		
	}
	
	
	public void Init(float width,float height, float startx,float starty,Material bound_material,float width_multiplier = 1f) {
		
		// this.width = width;
		// this.height = height;
		this.left = startx;
		this.right = startx+width;
		this.top = starty+height;
		this.bottom = starty;

		//初始化四条边
		GameObject bound_left = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_left = bound_left.GetComponent<LineRenderer>();
		Vector3[] leftpos = {new Vector3(startx,starty,100f),new Vector3(startx,starty+height,100f)};
		lr_left.SetPositions(leftpos);
		bound_left.GetComponent<MapBoundSingle>().Init(bound_material,width_multiplier);

		GameObject bound_right = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_right = bound_right.GetComponent<LineRenderer>();
		Vector3[] rightpos = {new Vector3(startx+width,starty,100f),new Vector3(startx+width,starty+height,100f)};
		lr_right.SetPositions(rightpos);
		bound_right.GetComponent<MapBoundSingle>().Init(bound_material,width_multiplier);

		GameObject bound_top = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_top = bound_top.GetComponent<LineRenderer>();
		Vector3[] toppos = {new Vector3(startx,starty+height,100f),new Vector3(startx+width,starty+height,100f)};
		lr_top.SetPositions(toppos);
		bound_top.GetComponent<MapBoundSingle>().Init(bound_material,width_multiplier);

		GameObject bound_bottom = Instantiate(mapBoundSingle,transform);
		LineRenderer lr_bottom = bound_bottom.GetComponent<LineRenderer>();
		Vector3[] bottompos = {new Vector3(startx,starty,100f),new Vector3(startx+width,starty,100f)};
		lr_bottom.SetPositions(bottompos);
		bound_bottom.GetComponent<MapBoundSingle>().Init(bound_material,width_multiplier);

		//小地图用粗边缘
		GameObject mini_bound_left = Instantiate(mapBoundSingleMinimap,transform);
		LineRenderer mini_lr_left = mini_bound_left.GetComponent<LineRenderer>();
		mini_lr_left.SetPositions(leftpos);
		mini_bound_left.GetComponent<MapBoundSingleMinimap>().Init(bound_material,width_multiplier);

		GameObject mini_bound_right = Instantiate(mapBoundSingleMinimap,transform);
		LineRenderer mini_lr_right = mini_bound_right.GetComponent<LineRenderer>();
		mini_lr_right.SetPositions(rightpos);
		mini_bound_right.GetComponent<MapBoundSingleMinimap>().Init(bound_material,width_multiplier);

		GameObject mini_bound_top = Instantiate(mapBoundSingleMinimap,transform);
		LineRenderer mini_lr_top = mini_bound_top.GetComponent<LineRenderer>();
		mini_lr_top.SetPositions(toppos);
		mini_bound_top.GetComponent<MapBoundSingleMinimap>().Init(bound_material,width_multiplier);

		GameObject mini_bound_bottom = Instantiate(mapBoundSingleMinimap,transform);
		LineRenderer mini_lr_bottom = mini_bound_bottom.GetComponent<LineRenderer>();
		mini_lr_bottom.SetPositions(bottompos);
		mini_bound_bottom.GetComponent<MapBoundSingleMinimap>().Init(bound_material,width_multiplier);

	}

	public bool inside(Vector3 pos) {
		return (pos.x > left && pos.x < right && pos.y > bottom && pos.y < top);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
