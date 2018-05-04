using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//事件基类
public abstract class EventObject : MonoBehaviour {

    [Header("物体设定")]
    [SerializeField] [Tooltip("行为模式")] Material bound_material;
    void Start () {

	}

    protected virtual void finish() {
        
        return;
    }
    
}
