using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideCameraFollow : MonoBehaviour {

	void FixedUpdate () {
		transform.position = Camera.main.transform.position;
	}
}
