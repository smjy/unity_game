using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class item_block : MonoBehaviour {

    Image image;
    Button button;
    
     Text NUM;
  
	// Use this for initialization
	void Start () {
        image = transform.Find("Image").GetComponent<Image>();
        button = GetComponent<Button>();
        NUM = transform.Find("Text").GetComponent<Text>();
        NUM .text= "";
        

    }
	
	// Update is called once per frame
	void Update () {
      
        NUM = transform.Find("Text").GetComponent<Text>();
    }
    public void setBlockImage(Sprite texture)
    {
        image.sprite = texture;
        image.preserveAspect = true;
        
    }
    public void setNum(int n)
    {
        NUM.text = n.ToString();
    }
    public void setName(string name)
    {
       
    }
}
