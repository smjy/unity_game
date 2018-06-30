using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyRegion : Region {
//空区域 当生成区域时所有其他区域均不满足条件时会生成

	public override int getPower(int x,int y,int depth,int seed) {
        return 1;
    }

	
}
