using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreebodyController : MonoBehaviour {

    Rigidbody rb;
    public float startSpeed = 45f;
    public float forceParam = 20f;
    public Transform tb1;
    public Transform tb2;
    public Transform tbcenter;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(startSpeed * Random.onUnitSphere);

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diff1 = transform.position - tb1.position ;
        Vector3 diff2 = transform.position - tb2.position ;
        Vector3 diffc = tbcenter.position - transform.position;
        rb.AddForce(forceParam * diff1.normalized / diff1.magnitude * diff1.magnitude);
        rb.AddForce(forceParam * diff2.normalized / diff2.magnitude * diff2.magnitude);
        rb.AddForce(forceParam * diffc.normalized * diffc.magnitude);

    }
}
