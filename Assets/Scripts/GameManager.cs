using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject particles;
    public int particles_num = 200;
    public Transform particle_parent;
    [Tooltip("环境所处Z轴")] public static float z_depth = 100f;
    [Tooltip("物体最小Z轴可视")] public static float z_min = 30f;
    [Tooltip("物体最大Z轴可视")] public static float z_max = 200f;

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
