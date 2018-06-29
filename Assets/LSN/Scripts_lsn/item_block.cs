using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class item_block : MonoBehaviour {

    Image image;
    
    Button button;
    public Sprite nullImage;
    [HideInInspector]
    public Sprite sprite;
    Text NUM;
    int num=0;
    public string NAME;
    
    public bool isNull=true;
	// Use this for initialization
	void Start () {
        
        image = transform.Find("Image").GetComponent<Image>();
        button = GetComponent<Button>();
        NUM = transform.Find("Text").GetComponent<Text>();
        NUM .text= "";
        isNull = true;

        NUM = transform.Find("Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
      
      
    }
    public void setBlockImage(Sprite texture)
    {
        sprite = texture;
        image.sprite = texture;
        image.preserveAspect = true;
        isNull = false;
        
    }
    public void setNum(int n)
    {
        if(n>1)
        {
            NUM.text = n.ToString();
            num = n;
            isNull = false;
        }
        else if(n==1)
        {
            num = n;
            isNull = false;
            NUM.text = "";
        }
        else if(n==0)
        {
            num = n;
            isNull = true;
            NUM.text = "";
            NAME = "";
            sprite = nullImage;
            image.sprite = sprite;
           // Debug.Log(NUM.text+"x");
        }
        
    }
    public void setName(string name)
    {
        NAME = name;
    }
    
    public int getnum()
    {
        return num;
    }
}
