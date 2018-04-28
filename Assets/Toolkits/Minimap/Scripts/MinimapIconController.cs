using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MinimapIconController : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	RectTransform rect;
	void Start () {
	}
	void Awake(){
		rect = GetComponent<RectTransform>();
	}
	// Update is called once per frame
	void Update () {
        rect = GetComponent<RectTransform>();
		Vector2 pos = Camera.main.WorldToViewportPoint(target.transform.position);
		transform.localPosition = new Vector2(Mathf.Clamp((pos.x-0.5f)*90,-90,90),Mathf.Clamp((pos.y - 0.5f) * 90, -90, 90));
	}
}
