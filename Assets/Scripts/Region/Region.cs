using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Region : MonoBehaviour {

    protected bool visited = false; //是否访问过
    protected int bound_type = MapManager.BOUND_NORMAL;
    //获取权重
    public virtual int getPower(int x,int y,int depth,int seed) {
        return 0;
    }
 
    void Start () {

	}
	
}
