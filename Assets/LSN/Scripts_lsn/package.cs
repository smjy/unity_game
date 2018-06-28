using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class package : MonoBehaviour {

    panel package_panel;
    int selected_index = -1;
    Image display;
    Text text;
	// Use this for initialization
	void Start () {
        package_panel = transform.Find("weapons_panel").GetComponent<panel>();
        display = transform.Find("Image").GetComponent<Image>();
        text = transform.Find("Text").GetComponent<Text>();
        text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void additem(item i)
    {
        package_panel.addItem(i);
    }
    public void selected_item(int i)
    {
        display.sprite = package_panel.weapons[i].sprite;
        text.text= package_panel.weapons[i].description;
    }
   
}
