using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {

    public static PlayerStat main;

    
    [Header("玩家数据")]
	[Tooltip("代码块")] public int code_blocks = 100;
    [Tooltip("内存")] public float memory = 1024;

	private void Awake() {
        if (main == null)
            main = this;
        else if (main != this)
            Destroy(gameObject);  
    }
   
}
