using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float z_para = 20f;

    MainPlayer_Single mm;
    Rigidbody rb;

    void Start()
    {
        mm = MainPlayer_Single.me;
        Debug.Log(mm);
        rb = mm.GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void FixedUpdate()
    {
        float mv = rb.velocity.magnitude;
        
        Vector3 vv = new Vector3(mm.transform.position.x, mm.transform.position.y, -mv/500f*z_para);
        float delta = 10 * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, vv, delta);

    }
}
