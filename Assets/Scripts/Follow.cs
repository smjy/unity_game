using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float z_para = 80f;

    MainPlayer_Single mm;
    Rigidbody rb;
    int rotatestate = 0;
    float rotatemax = 20f;
    void Start()
    {
        mm = MainPlayer_Single.me;
        rb = mm.GetComponent<Rigidbody>();
    }

    void Update() {
        rotatestate = 0;
        if (CommandInput.main != null && CommandInput.main.N()) 
            return;

        if (Input.GetKey(KeyCode.Q)) 
            rotatestate --;
        if (Input.GetKey(KeyCode.E))
            rotatestate ++;  
        
    }
    // Use this for initialization
    void FixedUpdate()
    {
        
        float mv = rb.velocity.magnitude;
        
        Vector3 vv = new Vector3(mm.transform.position.x, mm.transform.position.y, -mv/500f*z_para);
        float delta = 10 * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, vv, delta);

        Vector3 la = transform.localEulerAngles;
        if (la.y > rotatemax+1) la.y -= 360f;
        float rotateTarget = rotatestate * rotatemax;
        la.y = 0.8f*la.y + 0.2f*rotateTarget;
        transform.localEulerAngles = la;
    }
}
