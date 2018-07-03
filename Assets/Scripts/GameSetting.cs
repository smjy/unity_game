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
        public string[] functions = new string[11]
        {
            "Forward",
            "Back",
            "Left",
            "Right",
            "Left Leaning",
            "Right Leaning",
            "Command Input",
            "Command Output",
            "Item",
            "Command Info",
            "Menu"
       };
       public KeyCode[] keySetDefaults = new KeyCode[11]
        {
             KeyCode.W,
             KeyCode.A,
             KeyCode.S,
             KeyCode.D,
             KeyCode.Q,
             KeyCode.E,
             KeyCode.Return,
             KeyCode.Tab,
             KeyCode.I,
             KeyCode.C,
             KeyCode.Escape
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

            KeySetManager.InitializeDictionary();
        }

}
