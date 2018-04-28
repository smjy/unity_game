using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Region : MonoBehaviour {

    protected bool visited;
    protected bool has_user;
    protected int bound_type = MapManager.BOUND_NORMAL;
    protected List<Vector2> blockList;
    
    //获取权重
    public virtual int getPower(int x,int y,int depth,int seed) {
        return 1;
    }
    
    protected void addBlock(int x,int y) {
        blockList.Add(new Vector2(x,y));
    }
    void Start () {

	}
	
}
