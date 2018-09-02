using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoLoad : MonoBehaviour {

	VideoPlayer vp;
	public GameObject next;
	bool aa = false;
	// Use this for initialization
	void Awake () {
		vp = GetComponent<VideoPlayer>();
	}
	IEnumerator w3() {
		yield return new WaitForSeconds(3);
		next.SetActive(true);
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		if (!vp.isPlaying && !aa) {
			aa = true;
			StartCoroutine(w3());
			
		} 
	}
}
