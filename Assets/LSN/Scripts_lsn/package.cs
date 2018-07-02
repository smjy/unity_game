using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class package : MonoBehaviour {

    panel package_panel;
    //int selected_index = -1;
    Image display;
    Animator anim;
    Text text_description;
    Text text_name;
    public Sprite nodisplay;
    int selected = -1;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        package_panel = transform.Find("weapons_panel").GetComponent<panel>();
        display = transform.Find("Image").GetComponent<Image>();
        text_description = transform.Find("Text_description").GetComponent<Text>();
        text_description.text = "";
        text_name = transform.Find("Text_weaponsname").GetComponent<Text>();
        text_name.text = "";
        package_panel.initial_panel();
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
        if(!package_panel.blocks[i].isNull)
        {
            
            selected = i;
            display.sprite = package_panel.blocks[i].sprite;
            int n = package_panel.findweapons(package_panel.blocks[i].NAME);
            text_name.text = package_panel.blocks[i].NAME;
            text_description.text = package_panel.weapons[n].description;

        } 
    }
   public void close()
    {
        anim.SetBool("isout", true);
    }
   public void delete()
    {
        if(selected!=-1)
        {
           
            package_panel.deleteItem(selected);
            display.sprite =nodisplay;
            text_name.text = "";
            text_description.text = "";
        }
    }
}
