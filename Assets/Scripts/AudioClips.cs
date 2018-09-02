using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioClips : MonoBehaviour {

	public AudioClip[] ac;

	[HideInInspector] public AudioSource ass;
	public static AudioClips main;

	private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
		
		ass = GetComponent<AudioSource>();
    }
	
	public void play(int i) {
		ass.PlayOneShot(ac[i]);
	}

}
