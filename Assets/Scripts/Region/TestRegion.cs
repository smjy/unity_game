using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//范例Region
public class TestRegion : Region {
  
    //获取权重
    public override int getPower(int x,int y,int depth,int seed) {
        if (fullSurrounding(x,y)) return -1;
        Random.InitState(seed);

        int power = 0;
        //如果希望指定深度
        //if (depth < 3 && depth > 7) return -1;

        //一个二次函数分布
        //power +=  Mathf.RoundToInt(20-Mathf.Pow(depth-5,4)+Random.Range(1,10));

        //邻域判断
        int audio_card_surrounds = MapManager.main.surrounds(x,y,"audio_card");
        power += audio_card_surrounds * 3;

        power += 1;
        return power;
    }
 

}
