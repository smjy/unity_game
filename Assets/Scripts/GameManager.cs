using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject particles;
    public int particles_num = 200;
    public Transform particle_parent;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < particles_num; i++) {
            Instantiate(particles, particle_parent);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
