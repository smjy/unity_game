using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{

    // Use this for initialization
    public MainPlayer_Single character;
	public float rotateScale = 20f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		float x = character.rb.velocity.y / character.maxSpeed * rotateScale;
        float y = character.rb.velocity.x / character.maxSpeed * rotateScale;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(x,-15,15), Mathf.Clamp(y,-15,15), 0);
		print(x+" "+y);
    }
}
