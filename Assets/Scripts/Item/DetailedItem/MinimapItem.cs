using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapItem : item {
    //获得时触发
    public override void OnObtain() {
        StoryChapter1.main.activeMinimap();
    }
}
