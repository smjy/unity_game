using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour {

   
        public static GameSetting main;
        public double mainVoice; //主音量
        public double bgUusic;  //背景音乐
        public double gmSound; //音效
        public string windowSize="Full"; //窗口尺寸
        public string pictureQuality; //画面质量
        public string language; //语言

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
