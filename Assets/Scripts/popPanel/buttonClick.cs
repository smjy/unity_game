using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour {
    GameObject panel1,panel2;
    public Sprite bg,img;
	// Use this for initialization
	void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(clicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clicked()
    {
        //文字面板
      // panel1=popup.main.pop("通知","这是一个通知面板，请选择确定或者取消,试想一下度如何那个如果汇入",26);
       // panel1.pop("第一个面板");
       //图片面板
       panel2= imagePopup.main.popHaBtn("通知", "这是一个带图片的通知面板，请选择确定或者取消，试一下换行",img,10);

    }
   
}
