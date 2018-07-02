using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class StoryFade : MonoBehaviour {

	public int fade_time = 3;
	int time = 0;
	Image i;

	void Awake() {
		i = GetComponent<Image>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		time++;
		if (time == fade_time*50) Destroy(gameObject);
		float alpha = 1f - (float)time / (float)(fade_time*50);
		i.color = new Color(0f,0f,0f,alpha);
	}
}
