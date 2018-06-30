using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class popup : MonoBehaviour {
    public GameObject prePanel;
    GameObject myPanel; 
    Text[] myTitle;  // content title 
    Button[] myBtn; //0-2 返回、确定、取消
    Image[] myImg;  //0-3 panel 返回按钮 确认按钮 取消按钮
    public Sprite nor, high,nor_back,high_back;
    public static popup main;
    void Awake()
    {
        main = this;
    }
    //无确认取消按钮
    //修改标题、内容 
    public GameObject pop(string title,string content)
    {
        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform,false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();  
        myTitle[0].text=content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };


        //不显示两个按钮
        Color opa = new Color(1, 1, 1, 0.0f);
        myBtn[1].GetComponent<Image>().color = opa;
        myBtn[1].GetComponentInChildren<Text>().color = opa;
        myBtn[2].GetComponent<Image>().color = opa;
        myBtn[2].GetComponentInChildren<Text>().color = opa;
        return myPanel;
    }
    //无确认取消按钮
    //修改标题、内容 、字号
    public GameObject pop(string title, string content,int fSize)
    {
        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //修改字号
        myTitle[0].fontSize= fSize;

        //不显示两个按钮
        Color opa = new Color(1, 1, 1, 0.0f);
        myBtn[1].GetComponent<Image>().color = opa;
        myBtn[1].GetComponentInChildren<Text>().color = opa;
        myBtn[2].GetComponent<Image>().color = opa;
        myBtn[2].GetComponentInChildren<Text>().color = opa;
        return myPanel;
    }
    //无图片、无确认取消按钮
    //修改标题、内容、字号、设置面板缩放量
    public GameObject pop(string title, string content,int fSize, float scaleWidth,float scaleHeight)
    {
        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //修改字号
        myTitle[0].fontSize = fSize;
        //设置缩放量
        var rt = myPanel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(scaleWidth, scaleHeight, 1f);

        //不显示两个按钮
        Color opa = new Color(1, 1, 1, 0.0f);
        myBtn[1].GetComponent<Image>().color = opa;
        myBtn[1].GetComponentInChildren<Text>().color = opa;
        myBtn[2].GetComponent<Image>().color = opa;
        myBtn[2].GetComponentInChildren<Text>().color = opa;
        return myPanel;
    }
    //无确认取消按钮
    //修改标题、内容、字号、背景图
    public GameObject pop(string title, string content,int fSize,Sprite bg)
    {
        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //修改字号
        myTitle[0].fontSize = fSize;
        //设置背景图
        myPanel.GetComponent<Image>().sprite=bg;
        //不显示两个按钮
        Color opa = new Color(1, 1, 1, 0.0f);
        myBtn[1].GetComponent<Image>().color = opa;
        myBtn[1].GetComponentInChildren<Text>().color = opa;
        myBtn[2].GetComponent<Image>().color = opa;
        myBtn[2].GetComponentInChildren<Text>().color = opa;
        return myPanel;
    }
   
    //有确认取消按钮
    //修改标题、文字内容
    public GameObject popHaBtn(string title, string content)
    {

        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
           // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
           // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        //确认按钮
        myBtn[1].onClick.AddListener(sureClicked);
        //按钮高亮
        buttonstatus btnListener = myBtn[1].gameObject.AddComponent<buttonstatus>();
        Color32 highcolor = new Color32(179, 176, 198, 255);
        Color32 norcolor = new Color32(192, 120, 249, 255);
        btnListener.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;
            
            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color =norcolor;
        };

        btnListener.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //取消按钮
        myBtn[2].onClick.AddListener(cancelClicked);
        buttonstatus btnListener2 = myBtn[2].gameObject.AddComponent<buttonstatus>();
        btnListener2.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener2.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener2.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        return myPanel;
    }
    //有确认取消按钮
    //修改标题、文字内容,修改字号
    public GameObject popHaBtn(string title, string content,int fSize)
    {

        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //修改字号
        myTitle[0].fontSize = fSize;
        //确认按钮
        myBtn[1].onClick.AddListener(sureClicked);
        //按钮高亮
        buttonstatus btnListener = myBtn[1].gameObject.AddComponent<buttonstatus>();
        Color32 highcolor = new Color32(179, 176, 198, 255);
        Color32 norcolor = new Color32(192, 120, 249, 255);
        btnListener.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //取消按钮
        myBtn[2].onClick.AddListener(cancelClicked);
        buttonstatus btnListener2 = myBtn[2].gameObject.AddComponent<buttonstatus>();
        btnListener2.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener2.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener2.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        return myPanel;
    }
    //有确认取消按钮
    //修改标题、内容、修改字号，设置面板缩放量
    public GameObject popHaBtn(string title, string content,int fSize, float scaleWidth, float scaleHeight)
    {
        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //修改字号
        myTitle[0].fontSize = fSize;
        //设置缩放量
        var rt = myPanel.GetComponent<RectTransform>();
        rt.localScale = new Vector3(scaleWidth, scaleHeight, 1f);
     
        //确认按钮
        myBtn[1].onClick.AddListener(sureClicked);
        //按钮高亮
        buttonstatus btnListener = myBtn[1].gameObject.AddComponent<buttonstatus>();
        Color32 highcolor = new Color32(179, 176, 198, 255);
        Color32 norcolor = new Color32(192, 120, 249, 255);
        btnListener.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //取消按钮
        myBtn[2].onClick.AddListener(cancelClicked);
        buttonstatus btnListener2 = myBtn[2].gameObject.AddComponent<buttonstatus>();
        btnListener2.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener2.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener2.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        return myPanel;
    }
    //有确认取消按钮
    //修改标题、内容、字号，背景图
    public GameObject popHaBtn(string title, string content,int fSize, Sprite bg)
    {
        myPanel = GameObject.Instantiate(prePanel) as GameObject;
        myPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //设置标题名称和内容
        myTitle = myPanel.GetComponentsInChildren<Text>();
        myTitle[0].text = content;
        myTitle[1].text = title;
        //返回按钮
        myBtn = myPanel.GetComponentsInChildren<Button>();
        myBtn[0].onClick.AddListener(clicked);
        buttonstatus btnListener0 = myBtn[0].gameObject.AddComponent<buttonstatus>();
        btnListener0.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high_back;

            //gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener0.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener0.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor_back;
            // gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //修改字号
        myTitle[0].fontSize = fSize;
        //设置背景图
        myPanel.GetComponent<Image>().sprite = bg;

        //确认按钮
        myBtn[1].onClick.AddListener(sureClicked);
        //按钮高亮
        buttonstatus btnListener = myBtn[1].gameObject.AddComponent<buttonstatus>();
        Color32 highcolor = new Color32(179, 176, 198, 255);
        Color32 norcolor = new Color32(192, 120, 249, 255);
        btnListener.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        //取消按钮
        myBtn[2].onClick.AddListener(cancelClicked);
        buttonstatus btnListener2 = myBtn[2].gameObject.AddComponent<buttonstatus>();
        btnListener2.OnMouseEnter += delegate (GameObject gb) {

            Debug.Log("in");
            gb.GetComponent<Image>().sprite = high;

            gb.GetComponentInChildren<Text>().color = highcolor;
        };

        btnListener2.OnMouseExit += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };

        btnListener2.OnClick += delegate (GameObject gb) {
            Debug.Log("out");
            gb.GetComponent<Image>().sprite = nor;
            gb.GetComponentInChildren<Text>().color = norcolor;
        };
        return myPanel;
    }
  
    //返回按钮的点击事件
    void clicked()
    {
        Destroy(myPanel);

    }
    //确认按钮的点击事件
    void sureClicked()
    {

    }
    //取消按钮的点击事件
    void cancelClicked()
    {
        Destroy(myPanel);

    }


}
