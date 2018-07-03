using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CommandInfo : MonoBehaviour {
    Text NAME;
    public string command_name;
    public string command_info;
    public Text dispaly;
	// Use this for initialization
	public void initial () {
        NAME = transform.Find("Text").GetComponent<Text>();
        NAME.text = command_name;
        Debug.Log("1");
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void clicked()
    {
        dispaly.text = command_info;
    }
    public void setname(string n)
    {
        NAME.text = n;
        command_name = n;
    }
}
