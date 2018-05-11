using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//范例Region
public class TestRegion : Region {
  
    //获取权重
    public override int getPower(int x,int y,int depth,int seed) {
        if (fullSurrounding(x,y)) return -1;
        return 5;
    }
 
    void Start () {

	}
	

}
