using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour {

   
        public static GameSetting main;

        public bool mainVice_isUsed;
        public double mainVoice; //主音量
        public bool bgMusic_isUsed;
        public double bgMusic;  //背景音乐
        public bool gmSound_isUsed;
        public double gmSound; //音效
        public string windowSize="Full"; //窗口尺寸
        public string pictureQuality; //画面质量
        public string language; //语言
        public string[] functions = new string[5]
       {
            "Forward",
            "Back",
            "Left",
            "Right",
            "Function1"


       };
       public  KeyCode[] keySetDefaults = new KeyCode[5]
        {
             KeyCode.W,
             KeyCode.A,
             KeyCode.S,
             KeyCode.D,
             KeyCode.F1

        };

    private void Awake()
        {
            if (main == null)
            {
                main = this;
            }              
            else if (main != this)
            {
                //Destroy(gameObject);
            }

        }

}
