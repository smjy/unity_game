using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//事件基类
public abstract class Event : MonoBehaviour {

    
    public bool isGlobal = false; //是否为全局事件，如果是，则无需手动添加到region的prefab上
    protected int defaultPower = 0; //默认权重
    
    protected virtual void Start () {

	}

    protected virtual void finish() {

        return;
    }
    
}
