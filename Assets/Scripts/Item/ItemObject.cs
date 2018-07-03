using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//事件基类
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(item))]
public class ItemObject : MonoBehaviour {

    protected Rigidbody rb;
    protected item ii;
    protected virtual void Awake() {
        rb = GetComponent<Rigidbody>();
        ii = GetComponent<item>();
        //Debug.Log(ii == null);
    }
    
}
