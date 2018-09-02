using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;//头部引入
public class Video2 : MonoBehaviour {

	VideoPlayer vp;
	bool aa = false;
	// Use this for initialization
	void Awake () {
		vp = GetComponent<VideoPlayer>();
	}
	
	IEnumerator w3() {
		yield return new WaitForSeconds(3);

		SceneManager.LoadScene("1");
	}
	// Update is called once per frame
	void Update () {
		if (!vp.isPlaying && !aa) {
			StartCoroutine(w3());
			aa = true;
		} 
	}
}
